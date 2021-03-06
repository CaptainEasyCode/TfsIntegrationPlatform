﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50329.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;
using System.Collections;
using System;
// 
// This source code was auto-generated by xsd, Version=2.0.50329.0.
// 

namespace Microsoft.TeamFoundation.Converters.WorkItemTracking
{

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("Package")]
    public partial class WSPackage
    {
        // Base class for both InsertWorkItem and UpdateWOrkItem
        private WSWorkItemOperation[] workItemOperationsField;

        private string productField;
        private bool disableNotificationsField = true;

        /// <remarks/>
        [XmlElementAttribute("InsertWorkItem", Type = typeof(WSInsertWorkItem))]
        [XmlElementAttribute("UpdateWorkItem", Type = typeof(WSUpdateWorkItem))]
        public WSWorkItemOperation[] WorkItemOperations
        {
            get
            {
                return this.workItemOperationsField;
            }
            set
            {
                this.workItemOperationsField = value;
            }
        }

        /*
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InsertWorkItem", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public WSInsertWorkItem[] InsertWorkItem
        {
            get
            {
                return this.insertWorkItemField;
            }
            set
            {
                this.insertWorkItemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("UpdateWorkItem", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public WSUpdateWorkItem[] UpdateWorkItem
        {
            get
            {
                return this.updateWorkItemField;
            }
            set
            {
                this.updateWorkItemField = value;
            }
        }
        */
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Product
        {
            get
            {
                return this.productField;
            }
            set
            {
                this.productField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool DisableNotifications
        {
            get
            {
                return this.disableNotificationsField;
            }
            set
            {
                this.disableNotificationsField = value;
            }
        }
    }

    /// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [XmlInclude(typeof(WSInsertWorkItem))]
    [XmlInclude(typeof(WSUpdateWorkItem))]
    public class WSWorkItemOperation
    {

        private WSColumns columnsField;

        private ArrayList insertTextField;

        private ArrayList insertFileField;

        private ArrayList createRelationField;

        private ArrayList computedColumnsField;

        private ArrayList insertResourceField;

        private int bypassRulesField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Columns", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public WSColumns Columns
        {
            get
            {
                return this.columnsField;
            }
            set
            {
                this.columnsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InsertText", Type = typeof(WSInsertText))]
        public ArrayList InsertText
        {
            get
            {
                return this.insertTextField;
            }
            set
            {
                this.insertTextField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InsertFile", Type = typeof(WSInsertFile))]
        public ArrayList InsertFile
        {
            get
            {
                return this.insertFileField;
            }
            set
            {
                this.insertFileField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InsertResourceLink", Type = typeof(WSInsertResourceLink))]
        public ArrayList InsertResourceLink
        {
            get
            {
                return this.insertResourceField;
            }
            set
            {
                this.insertResourceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CreateRelation", Type = typeof(WSCreateRelation))]
        public ArrayList CreateRelation
        {
            get
            {
                return this.createRelationField;
            }
            set
            {
                this.createRelationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComputedColumns", typeof(WSComputedColumns))]
        public ArrayList ComputedColumns
        {
            get
            {
                return this.computedColumnsField;
            }
            set
            {
                this.computedColumnsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int BypassRules
        {
            get
            {
                return this.bypassRulesField;
            }
            set
            {
                this.bypassRulesField = value;
            }
        }
    }


    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class WSInsertWorkItem : WSWorkItemOperation
    {
    }

    /// <remarks/>
    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class WSUpdateWorkItem : WSWorkItemOperation
    {
        /*
        private WSColumns columnsField;
        private ArrayList insertTextField;
        private ArrayList insertFileField;
        private ArrayList createRelationField;
        private ArrayList computedColumnsField;
        private ArrayList insertResourceField;
        private int bypassRulesField;
        private string objectTypeField;
        */
        private int workItemIDField;
        private bool workItemIDFieldSpecified;

        private int revisionField;
        private bool revisionFieldSpecified;

        /*
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Columns", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public WSColumns Columns
        {
            get
            {
                return this.columnsField;
            }
            set
            {
                this.columnsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InsertText", typeof(WSInsertText))]
        public ArrayList InsertText
        {
            get
            {
                return this.insertTextField;
            }
            set
            {
                this.insertTextField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InsertFile", typeof(WSInsertFile))]
        public ArrayList InsertFile
        {
            get
            {
                return this.insertFileField;
            }
            set
            {
                this.insertFileField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("InsertResourceLink", Type = typeof(WSInsertResourceLink))]
        public ArrayList InsertResourceLink
        {
            get
            {
                return this.insertResourceField;
            }
            set
            {
                this.insertResourceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RemoveFile", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public WSRemoveFile[] RemoveFile
        {
            get
            {
                return this.removeFileField;
            }
            set
            {
                this.removeFileField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RemoveRelation", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public WSRemoveRelation[] RemoveRelation
        {
            get
            {
                return this.removeRelationField;
            }
            set
            {
                this.removeRelationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CreateRelation", typeof(WSCreateRelation))]
        public ArrayList CreateRelation
        {
            get
            {
                return this.createRelationField;
            }
            set
            {
                this.createRelationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComputedColumns", typeof(WSComputedColumns))]
        public ArrayList ComputedColumns
        {
            get
            {
                return this.computedColumnsField;
            }
            set
            {
                this.computedColumnsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int BypassRules
        {
            get
            {
                return this.bypassRulesField;
            }
            set
            {
                this.bypassRulesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ObjectType
        {
            get
            {
                return this.objectTypeField;
            }
            set
            {
                this.objectTypeField = value;
            }
        }
         */

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int WorkItemID
        {
            get
            {
                return this.workItemIDField;
            }
            set
            {
                this.workItemIDField = value;
                workItemIDFieldSpecified = true;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WorkItemIDSpecified
        {
            get
            {
                return this.workItemIDFieldSpecified;
            }
            set
            {
                this.workItemIDFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Revision
        {
            get
            {
                return this.revisionField;
            }
            set
            {
                this.revisionField = value;
                revisionFieldSpecified = true;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RevisionSpecified
        {
            get
            {
                return this.revisionFieldSpecified;
            }
            set
            {
                this.revisionFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class WSColumns
    {

        private ArrayList columnField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Column", typeof(WSColumn))]
        public ArrayList Column
        {
            get
            {
                return this.columnField;
            }
            set
            {
                this.columnField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class WSColumn
    {

        private string valueField;

        private string typeField;

        private string column1Field;

        public WSColumn()
        {
            this.typeField = "String";
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("String")]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("Column")]
        public string Column1
        {
            get
            {
                return this.column1Field;
            }
            set
            {
                this.column1Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class WSComputedColumns
    {

        private WSComputedColumn[] computedColumnField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ComputedColumn", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public WSComputedColumn[] ComputedColumn
        {
            get
            {
                return this.computedColumnField;
            }
            set
            {
                this.computedColumnField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class WSComputedColumn
    {

        private string columnField;

        public WSComputedColumn()
        {
        }

        public WSComputedColumn(string col)
        {
            Column = col;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Column
        {
            get
            {
                return this.columnField;
            }
            set
            {
                this.columnField = value;
            }
        }
    }

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class WSInsertText
    {

        private string fieldNameField;

        private string fieldDisplayNameField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FieldName
        {
            get
            {
                return this.fieldNameField;
            }
            set
            {
                this.fieldNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FieldDisplayName
        {
            get
            {
                return this.fieldDisplayNameField;
            }
            set
            {
                this.fieldDisplayNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class WSInsertFile
    {

        private string fileNameField;

        private string originalNameField;

        private string commentField;

        private System.DateTime creationDateField;

        private bool creationDateFieldSpecified;

        private System.DateTime lastWriteDateField;

        private bool lastWriteDateFieldSpecified;

        private long fileSizeField;

        private string areaNodeUri;
        private Guid fileGuid;
        private string fileNameWithPath;

        [XmlIgnore]
        public string FileNameWithPath
        {
            get { return fileNameWithPath; }
            set { fileNameWithPath = value; }
        }

        [XmlIgnore]
        public string AreaNodeUri
        {
            get { return areaNodeUri; }
            set { areaNodeUri = value; }
        }
        
        [XmlIgnore]
        public Guid FileGuid
        {
            get { return fileGuid; }
            set { fileGuid = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FileName
        {
            get
            {
                return this.fileNameField;
            }
            set
            {
                this.fileNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OriginalName
        {
            get
            {
                return this.originalNameField;
            }
            set
            {
                this.originalNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Comment
        {
            get
            {
                return this.commentField;
            }
            set
            {
                this.commentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public long FileSize
        {
            get
            {
                return this.fileSizeField;
            }
            set
            {
                this.fileSizeField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime CreationDate
        {
            get
            {
                return this.creationDateField;
            }
            set
            {
                this.creationDateField = value;
                CreationDateSpecified = true;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CreationDateSpecified
        {
            get
            {
                return this.creationDateFieldSpecified;
            }
            set
            {
                this.creationDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime LastWriteDate
        {
            get
            {
                return this.lastWriteDateField;
            }
            set
            {
                this.lastWriteDateField = value;
                LastWriteDateSpecified = true;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LastWriteDateSpecified
        {
            get
            {
                return this.lastWriteDateFieldSpecified;
            }
            set
            {
                this.lastWriteDateFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class WSRemoveFile
    {

        private int fileIDField;

        private bool fileIDFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int FileID
        {
            get
            {
                return this.fileIDField;
            }
            set
            {
                this.fileIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FileIDSpecified
        {
            get
            {
                return this.fileIDFieldSpecified;
            }
            set
            {
                this.fileIDFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute("ProductStudio-Issue-Update-Template", Namespace = "", IsNullable = false)]
    public partial class ProductStudioIssueUpdateTemplate
    {

        private object[] itemsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RemoveResourceLink", typeof(WSRemoveResourceLink), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("Package", typeof(WSPackage), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("InsertFile", typeof(WSInsertFile))]
        [System.Xml.Serialization.XmlElementAttribute("InsertResourceLink", typeof(WSInsertResourceLink), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("CreateRelation", typeof(WSCreateRelation))]
        [System.Xml.Serialization.XmlElementAttribute("ComputedColumns", typeof(WSComputedColumn[]))]
        [System.Xml.Serialization.XmlElementAttribute("UpdateResourceLink", typeof(WSUpdateResourceLink), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("Column", typeof(WSColumn))]
        [System.Xml.Serialization.XmlElementAttribute("InsertText", typeof(WSInsertText))]
        [System.Xml.Serialization.XmlElementAttribute("UpdateRelation", typeof(WSUpdateRelation), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class WSCreateRelation
    {

        private int workItemIDField;

        private bool workItemIDFieldSpecified;

        private string commentField;

        private string productField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int WorkItemID
        {
            get
            {
                return this.workItemIDField;
            }
            set
            {
                this.workItemIDField = value;
                workItemIDFieldSpecified = true;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Comment
        {
            get
            {
                return this.commentField;
            }
            set
            {
                this.commentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WorkItemIDSpecified
        {
            get
            {
                return this.workItemIDFieldSpecified;
            }
            set
            {
                this.workItemIDFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Product
        {
            get
            {
                return this.productField;
            }
            set
            {
                this.productField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class WSUpdateRelation
    {

        private int issueIDField;

        private bool issueIDFieldSpecified;

        private string commentField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int IssueID
        {
            get
            {
                return this.issueIDField;
            }
            set
            {
                this.issueIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IssueIDSpecified
        {
            get
            {
                return this.issueIDFieldSpecified;
            }
            set
            {
                this.issueIDFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Comment
        {
            get
            {
                return this.commentField;
            }
            set
            {
                this.commentField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class WSRemoveRelation
    {
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class WSInsertResourceLink
    {

        private string fieldNameField;

        private string locationField;

        private string commentField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FieldName
        {
            get
            {
                return this.fieldNameField;
            }
            set
            {
                this.fieldNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Location
        {
            get
            {
                return this.locationField;
            }
            set
            {
                this.locationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Comment
        {
            get
            {
                return this.commentField;
            }
            set
            {
                this.commentField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class WSRemoveResourceLink
    {

        private int idField;

        private bool idFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int ID
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IDSpecified
        {
            get
            {
                return this.idFieldSpecified;
            }
            set
            {
                this.idFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class WSUpdateResourceLink
    {

        private int idField;

        private bool idFieldSpecified;

        private string commentField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int ID
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IDSpecified
        {
            get
            {
                return this.idFieldSpecified;
            }
            set
            {
                this.idFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Comment
        {
            get
            {
                return this.commentField;
            }
            set
            {
                this.commentField = value;
            }
        }
    }

}