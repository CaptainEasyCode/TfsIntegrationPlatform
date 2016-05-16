﻿// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MigrationTestLibrary;

namespace Tfs2010WITTCAdapter
{
    [TCAdapterDescription(m_adapterGuid, m_adapterName)]
    public class Tfs2010WitTestCaseAdapter : ITfsWITTestCaseAdapter
    {
        private const string m_adapterGuid = "F8F18C95-764D-47e3-AB45-9ACD47CA8F82";
        private const string m_adapterName = "TFS 2010 WIT TestCase Adapter";

        private string m_filterString;

        public const string FIELD_PRIORITY = "Microsoft.VSTS.Common.Priority";
        public const string FIELD_ASSIGNEDTO = "System.AssignedTo";

        public event WorkItemAddedEventHandler WorkItemAdded;

        #region properties
        public WorkItemStore WorkItemStore { get; protected set; }
        protected string TeamProjectName { get; set; }
        protected Project Project { get; set; }
        #endregion

        public string FilterString
        {
            get
            {
                return m_filterString;
            }
        }

        public string WorkItemIDColumnName
        {
            get
            {
                return "[System.Id]";
            }
        }

        public string TitlePrefix { get; set; }

        private int m_witQueryCount;

        public string TitleQuery
        {
            get
            {
                return String.Format("[System.Id] > {0} AND [System.Title] CONTAINS '{1}' AND [System.TeamProject]='{2}'", this.m_witQueryCount, TitlePrefix, Project.Name);
            }
        }

        public void Initialize(EndPoint env)
        {
            Trace.TraceInformation("Tfs2010WitTestCaseAdapter: Initialize BEGIN");
            Trace.TraceInformation("ServerUrl: {0}", env.ServerUrl);
            Trace.TraceInformation("TeamProject: {0}", env.TeamProject);

            m_filterString = string.Empty;

            TfsTeamProjectCollection tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(env.ServerUrl));
            WorkItemStore = (WorkItemStore)tfs.GetService(typeof(WorkItemStore));
            TeamProjectName = env.TeamProject;
            Project = WorkItemStore.Projects[TeamProjectName];

            m_witQueryCount = WorkItemStore.QueryCount("SELECT [System.Id] From WorkItems");

            Trace.TraceInformation("Tfs2010WitTestCaseAdapter: Initialize END");
        }

        public void Cleanup()
        {
        }

        public int AddWorkItem(string type, string title, string desc)
        {
            int workItemId = SaveWorkItem(CreateWorkItemTemplate(Project, type, title, desc));
            if (WorkItemAdded != null)
            {
                WorkItemAdded(this, new WorkItemAddedEventArgs(workItemId));
            }
            return workItemId;
        }

        public void UpdateWorkItem(int workItemId, WITChangeAction action)
        {
            string condition = String.Format("[System.Id] = {0}", workItemId);
            WITUtil util = new WITUtil(WorkItemStore, TeamProjectName, condition, string.Empty);

            WorkItem wi = util.WorkItems[0];
            wi.Open();

            if (!String.IsNullOrEmpty(action.Title))
            {
                wi.Title = TitlePrefix + " " + action.Title;
            }

            if (!String.IsNullOrEmpty(action.Description))
            {
                wi.Description = action.Description;
            }

            if (!String.IsNullOrEmpty(action.History))
            {
                wi.History = action.History;
            }

            if (!String.IsNullOrEmpty(action.Reason))
            {
                wi.Reason = action.Reason;
            }

            if (!String.IsNullOrEmpty(action.Priority))
            {
                wi.Fields[FIELD_PRIORITY].Value = action.Priority;
            }

            if (!String.IsNullOrEmpty(action.AssignedTo))
            {
                wi.Fields[FIELD_ASSIGNEDTO].Value = action.AssignedTo;
            }

            ArrayList invalidFields = wi.Validate();
            if (invalidFields.Count != 0)
            {
                Assert.Fail("Failed to update work item: {0}", wi.Id);
            }

            wi.Save();
        }

        public void UpdateWorkItemLink(int workItemId, WITLinkChangeAction action)
        {
            string condition = String.Format("[System.Id] = {0}", workItemId);
            WITUtil util = new WITUtil(WorkItemStore, TeamProjectName, condition, string.Empty);

            WorkItem wi = util.WorkItems[0];
            wi.Open();

            foreach (WITLink witlink in action.Links)
            {
                // Support only Hyperlink
                Hyperlink link = new Hyperlink(witlink.Location);
                link.Comment = witlink.Comment;

                if (action.ActionType == LinkChangeActionType.Add)
                {
                    wi.Links.Add(link);
                }
                else if (action.ActionType == LinkChangeActionType.Delete)
                {
                    Link linkToDelete = FindHyperLink(link.Location, wi.Links);
                    if (linkToDelete != null)
                    {
                        wi.Links.Remove(linkToDelete);
                    }
                }
                // Update link's comment
                else if (action.ActionType == LinkChangeActionType.Edit)
                {
                    Link linkToEdit = FindHyperLink(link.Location, wi.Links);
                    if (linkToEdit != null)
                    {
                        linkToEdit.Comment = link.Comment;
                    }
                }
            }

            ArrayList invalidFields = wi.Validate();
            if (invalidFields.Count != 0)
            {
                Assert.Fail("Failed to update work item: {0}", wi.Id);
            }

            wi.Save();
        }

        public void UpdateAttachment(int workItemId, WITAttachmentChangeAction action)
        {
            string condition = String.Format("[System.Id] = {0}", workItemId);
            WITUtil util = new WITUtil(WorkItemStore, TeamProjectName, condition, string.Empty);

            WorkItem wi = util.WorkItems[0];
            wi.Open();

            foreach (WITAttachment attachment in action.Attachments)
            {
                if (attachment.ActionType == AttachmentChangeActionType.Add)
                {
                    wi.Attachments.Add(CreateAttachment(attachment.FileName, attachment.Comment));
                }
                else if (attachment.ActionType == AttachmentChangeActionType.Delete)
                {
                    Attachment item = FindAttachment(attachment.FileName, attachment.Comment, wi.Attachments);
                    if (item != null)
                    {
                        wi.Attachments.Remove(item);
                    }
                }
                // Update attachment comment
                else if (attachment.ActionType == AttachmentChangeActionType.Edit)
                {
                    throw new NotImplementedException("EditAttachment is not supported yet");
                    //Attachment item = FindAttachment(attachment.FileName, attachment.Comment, wi.Attachments);
                    //if (item != null)
                    //{
                    // TODO: Update comment
                    // Comment is read-only
                    //item.Comment = attachment.Comment;
                    //}
                }
            }

            ArrayList invalidFields = wi.Validate();
            if (invalidFields.Count != 0)
            {
                Assert.Fail("Failed to update work item: {0}", wi.Id);
            }

            wi.Save();
        }

        public void AddRelatedWorkItemLink(int workItemId, int relatedWorkItemId)
        {
            string condition = String.Format("[System.Id] = {0}", workItemId);
            WITUtil util = new WITUtil(WorkItemStore, TeamProjectName, condition, string.Empty);

            WorkItem wi = util.WorkItems[0];
            wi.Open();

            RelatedLink link = new RelatedLink(relatedWorkItemId);
            wi.Links.Add(link);

            wi.Save();
        }

        public void DeleteRelatedWorkItemLink(int workItemId, int relatedWorkItemId)
        {
            string condition = String.Format("[System.Id] = {0}", workItemId);
            WITUtil util = new WITUtil(WorkItemStore, TeamProjectName, condition, string.Empty);

            WorkItem wi = util.WorkItems[0];
            wi.Open();

            WorkItemLink link = null;
            foreach (WorkItemLink candidate in wi.WorkItemLinks)
            {
                if ((candidate.TargetId == relatedWorkItemId) && (candidate.LinkTypeEnd.Name == "Related"))
                {
                    link = candidate;
                    break;
                }
            }

            if (link != null)
            {
                wi.WorkItemLinks.Remove(link);
                wi.Save();
            }
            wi.Close();
        }

        public string GetFieldValue(int workItemId, string fieldName)
        {
            string condition = String.Format("[System.Id] = {0}", workItemId);
            WITUtil util = new WITUtil(WorkItemStore, TeamProjectName, condition, string.Empty);

            WorkItem wi = util.WorkItems[0];

            return wi.Fields[fieldName].Value.ToString();
        }

        public WITLink GetHyperLink(int workItemId, string location)
        {
            string condition = String.Format("[System.Id] = {0}", workItemId);
            WITUtil util = new WITUtil(WorkItemStore, TeamProjectName, condition, string.Empty);

            WorkItem wi = util.WorkItems[0];
            Hyperlink link = FindHyperLink(location, wi.Links);
            WITLink witLink = null;
            if (link != null)
            {
                witLink = new WITLink(link.Location, link.Comment);
            }

            return witLink;
        }

        public int AddWorkItem(string type, string title, string desc, string areaPath)
        {
            WorkItem wi = CreateWorkItemTemplate(Project, type, title, desc);
            wi.AreaPath = areaPath;

            return SaveWorkItem(wi);
        }

        public int GetHyperLinkCount(int workitemId)
        {
            string condition = String.Format("[System.Id] = {0}", workitemId);
            WITUtil util = new WITUtil(WorkItemStore, TeamProjectName, condition, string.Empty);

            WorkItem wi = util.WorkItems[0];

            return wi.HyperLinkCount;
        }

        public int GetRelatedLinkCount(int workitemId)
        {
            string condition = String.Format("[System.Id] = {0}", workitemId);
            WITUtil util = new WITUtil(WorkItemStore, TeamProjectName, condition, string.Empty);

            WorkItem wi = util.WorkItems[0];

            return wi.RelatedLinkCount;
        }

        public int GetAttachmentCount(int workitemId)
        {
            string condition = String.Format("[System.Id] = {0}", workitemId);
            WITUtil util = new WITUtil(WorkItemStore, TeamProjectName, condition, string.Empty);

            WorkItem wi = util.WorkItems[0];

            return wi.AttachedFileCount;
        }

        public void AddParentChildLink(int parentId, int childId)
        {
            AddParentChildLink(parentId, childId, false);
        }

        public void AddParentChildLink(int parentId, int childId, bool isLocked)
        {
            string condition = String.Format("[System.Id] = {0}", parentId);
            WITUtil util = new WITUtil(WorkItemStore, TeamProjectName, condition, string.Empty);

            WorkItem wi = util.WorkItems[0];
            wi.Open();

            var hierarchicalLink = WorkItemStore.WorkItemLinkTypes["System.LinkTypes.Hierarchy"];
            var link = new WorkItemLink(hierarchicalLink.ForwardEnd, childId);
            link.IsLocked = isLocked;
            wi.WorkItemLinks.Add(link);
            wi.Save();
        }

        public void DeleteParentChildLink(int parentId, int childId)
        {
            string condition = String.Format("[System.Id] = {0}", parentId);
            WITUtil util = new WITUtil(WorkItemStore, TeamProjectName, condition, string.Empty);

            WorkItem wi = util.WorkItems[0];
            wi.Open();

            WorkItemLink link = null;
            foreach (WorkItemLink candidate in wi.WorkItemLinks)
            {
                if ((candidate.TargetId == childId) && (candidate.LinkTypeEnd.Name == "Child"))
                {
                    link = candidate;
                    break;
                }
            }

            if (link != null)
            {
                wi.WorkItemLinks.Remove(link);
                wi.Save();
            }
            wi.Close();
        }

        public void AddScenarioExperienceLink(int scenarioId, int experienceId)
        {
            string condition = String.Format("[System.Id] = {0}", scenarioId);
            WITUtil util = new WITUtil(WorkItemStore, TeamProjectName, condition, string.Empty);

            WorkItem wi = util.WorkItems[0];
            wi.Open();

            var scenarioExperienceLink = WorkItemStore.WorkItemLinkTypes["Microsoft.DevDiv.ScenarioExperience"];
            var link = new WorkItemLink(scenarioExperienceLink.ForwardEnd, experienceId);
            link.IsLocked = false;
            wi.WorkItemLinks.Add(link);
            wi.Save();
        }

        public void DeleteScenarioExperienceLink(int scenarioId, int experienceId)
        {
            string condition = String.Format("[System.Id] = {0}", scenarioId);
            WITUtil util = new WITUtil(WorkItemStore, TeamProjectName, condition, string.Empty);

            WorkItem wi = util.WorkItems[0];
            wi.Open();

            WorkItemLink link = null;
            foreach (WorkItemLink candidate in wi.WorkItemLinks)
            {
                if ((candidate.TargetId == experienceId) && (candidate.LinkTypeEnd.Name == "Scenario-Experience"))
                {
                    link = candidate;
                    break;
                }
            }

            if (link != null)
            {
                wi.WorkItemLinks.Remove(link);
                wi.Save();
            }
            wi.Close();
        }

        #region private methods
        private WorkItem CreateWorkItemTemplate(Project project, string type, string title, string desc)
        {
            WorkItemType wit = project.WorkItemTypes[type];
            WorkItem wi = new WorkItem(wit);
            wi.Title = TitlePrefix + " " + title;
            wi.Description = desc;

            return wi;
        }

        private Attachment CreateAttachment(string filename, string comment)
        {
            string path = TestUtils.CreateRandomFile(Path.Combine(TestUtils.TextReportRoot, filename), 10);
            return new Attachment(path, comment);
        }

        private int SaveWorkItem(WorkItem wi)
        {
            int newWorkItemId = -1;

            ArrayList invalidFields = wi.Validate();
            if (invalidFields.Count != 0)
            {
                Assert.Fail("Failed to create a workitem. Type:{0} Title:{1}", wi.Type.Name, wi.Title);
                return newWorkItemId;
            }

            wi.Save();
            newWorkItemId = wi.Id;
            Trace.TraceInformation("Created a workitem.  Id:{0} Type:{1} Title:'{2}'", wi.Id, wi.Type.Name, wi.Title);
            //Trace.TraceInformation("Sleeping 1000 ms");            
            //System.Threading.Thread.Sleep(1000);
            return newWorkItemId;
        }

        // Find a hyperlink from the given link collection. 
        private Hyperlink FindHyperLink(string location, LinkCollection linkCollection)
        {
            Hyperlink result = null;
            foreach (Link item in linkCollection)
            {
                if (item.BaseType != BaseLinkType.Hyperlink)
                {
                    continue;
                }

                Hyperlink hyperlink = (Hyperlink)item;
                if (hyperlink.Location.Equals(location))
                {
                    result = hyperlink;
                    break;
                }
            }

            return result;
        }

        private Attachment FindAttachment(string name, string comment, AttachmentCollection attachmentCollection)
        {
            foreach (Attachment attachment in attachmentCollection)
            {
                if (String.Equals(attachment.Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    return attachment;
                }
            }

            return null;
        }
        #endregion

        #region ITfsWITTestCaseAdapter Members


        public bool IsLinkLocked(int parentId, int childId)
        {
            string condition = String.Format("[System.Id] = {0}", parentId);
            WITUtil util = new WITUtil(WorkItemStore, TeamProjectName, condition, string.Empty);

            WorkItem wi = util.WorkItems[0];
            wi.Open();

            WorkItemLink link = null;
            foreach (Link l in wi.WorkItemLinks)
            {
                WorkItemLink wil = l as WorkItemLink;

                if (wil != null)
                {
                    if (wil.TargetId == childId)
                    {
                        link = l as WorkItemLink;
                        break;
                    }
                }
            }

            Debug.Assert(link != null, "link is null");
            return link.IsLocked;
        }

        public void UpdateLinkLockOption(int parentId, int childId, bool isLocked)
        {
            string condition = String.Format("[System.Id] = {0}", parentId);
            WITUtil util = new WITUtil(WorkItemStore, TeamProjectName, condition, string.Empty);

            WorkItem wi = util.WorkItems[0];
            wi.Open();

            WorkItemLink link = null;
            foreach (Link l in wi.WorkItemLinks)
            {
                WorkItemLink wil = l as WorkItemLink;

                if (wil != null)
                {
                    if (wil.TargetId == childId)
                    {
                        link = l as WorkItemLink;
                        break;
                    }
                }
            }

            Debug.Assert(link != null, "link is null");
            link.IsLocked = isLocked;
            wi.Save();
        }

        #endregion

        public WorkItem GetWorkItem(int workItemId)
        {
            string condition = String.Format("[System.Id] = {0}", workItemId);
            WITUtil util = new WITUtil(WorkItemStore, TeamProjectName, condition, string.Empty);

            WorkItem wi = util.WorkItems[0];
            wi.Open();
            return wi;
        }
    }
}