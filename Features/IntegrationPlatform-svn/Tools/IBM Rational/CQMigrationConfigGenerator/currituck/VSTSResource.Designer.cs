﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.TeamFoundation.Converters.WorkItemTracking {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class VSTSResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal VSTSResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CQConverter.currituck.VSTSResource", typeof(VSTSResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TF26176: Team Foundation could not find the registration for the application server URL. Contact your Team Foundation Server administrator..
        /// </summary>
        internal static string ErrorBisMiddleTierNotRegistered {
            get {
                return ResourceManager.GetString("ErrorBisMiddleTierNotRegistered", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TF61000: The converter could not convert work item {0}. The field &apos;{1}&apos; has an unsupported value &apos;{2}&apos;, and the default value is also not supported. Check the value mappings and default values in the field map file &apos;{3}&apos;.  Please provide a valid default value and run the converter again to migrate the work item..
        /// </summary>
        internal static string InvalidDefaultValueMap {
            get {
                return ResourceManager.GetString("InvalidDefaultValueMap", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TF61001: Unable to start migration. File {0} contains unsupported attribute value &apos;{1}&apos; for &apos;refer&apos;. Only &apos;UserMap&apos; value is supported for this attribute. Run the converter again after fixing the attribute value..
        /// </summary>
        internal static string InvalidFieldMapReference {
            get {
                return ResourceManager.GetString("InvalidFieldMapReference", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TF61002: Unable to start migration. Field Map validation failed for file &apos;{0}&apos;. Field(s) &apos;{1}&apos; does not exist in work item type &apos;{2}&apos; in Team Foundation Server. Please create these fields in your work item type or remove the fields from the field map file..
        /// </summary>
        internal static string InvalidFieldName {
            get {
                return ResourceManager.GetString("InvalidFieldName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TF61004: Unable to start migration. The converter could not find the team project &apos;{0}&apos; on the Team Foundation Server &apos;{1}&apos;. Please provide the name of an existing team project or create the team project and try again..
        /// </summary>
        internal static string InvalidProject {
            get {
                return ResourceManager.GetString("InvalidProject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid structure node..
        /// </summary>
        internal static string InvalidStructureNode {
            get {
                return ResourceManager.GetString("InvalidStructureNode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TF61008: The converter could not convert work item &apos;{0}&apos;. The field &apos;{1}&apos; has an unsupported value &apos;{2}&apos;, and there is no default value specified in the field map file &apos;{3}&apos;. Please provide a default value and try again..
        /// </summary>
        internal static string NullDefaultValueMap {
            get {
                return ResourceManager.GetString("NullDefaultValueMap", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TF61025: Unable to serialize object due to unknown error: {0}.
        /// </summary>
        internal static string SerializingWSFailed {
            get {
                return ResourceManager.GetString("SerializingWSFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Using: &apos;{0}&apos; instead of: &apos;{1}&apos; for: &apos;{2}&apos;.
        /// </summary>
        internal static string UsingDefaultValue {
            get {
                return ResourceManager.GetString("UsingDefaultValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Validating the Team Foundation fields in the converter mappings.
        /// </summary>
        internal static string ValidatingVSTSFieldsStart {
            get {
                return ResourceManager.GetString("ValidatingVSTSFieldsStart", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Updated by converter for creating Attachments and Links.
        /// </summary>
        internal static string VstsAttachmentLinkHistory {
            get {
                return ResourceManager.GetString("VstsAttachmentLinkHistory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TF61015: Attachment &apos;{0}&apos; save failed for work item &apos;{1}&apos; with the following error: {2}. Please fix the source of the error and run the converter again to get that attachment..
        /// </summary>
        internal static string VstsAttachmentUploadFailed {
            get {
                return ResourceManager.GetString("VstsAttachmentUploadFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot edit field &apos;{0}&apos; as is a internal core field in Team Foundation Work Item Tracking system..
        /// </summary>
        internal static string VstsCannotEditFields {
            get {
                return ResourceManager.GetString("VstsCannotEditFields", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Connecting to the Team Foundation Server [Server: {0}, Team Project: {1}].
        /// </summary>
        internal static string VstsConnectionStart {
            get {
                return ResourceManager.GetString("VstsConnectionStart", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TF61009: Unable to start migration. The User Map file &apos;{0}&apos; contains unrecognized Team Foundation users. Check that the users specified in the User Map file are all existing Team Foundation users or remove them from the User Map file. Unrecognized users: {1}.
        /// </summary>
        internal static string VstsInvalidUsers {
            get {
                return ResourceManager.GetString("VstsInvalidUsers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TF61022: The Work Item Type Definition file &apos;{0}&apos; specified in schema map file &apos;{1}&apos; is not a valid xml file.
        ///Issue: {2}
        ///Line: {3}
        ///Column: {4}. Please create a valid file by referring to the file schema in the help documents and try again..
        /// </summary>
        internal static string VstsInvalidXmlFile {
            get {
                return ResourceManager.GetString("VstsInvalidXmlFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TF61021: The Work Item Type Definition file &apos;{0}&apos; specified in schema map file &apos;{1}&apos; is invalid. It does not contain &apos;name&apos; attribute under &apos;WORKITEMTYPE\WITD&apos; node. Please create a valid file by referring to the file schema in the help documents and try again..
        /// </summary>
        internal static string VstsNoNameAttribute {
            get {
                return ResourceManager.GetString("VstsNoNameAttribute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TF61019: Unable to start migration. The Work Item Type Definition file &apos;{0}&apos; specified in schema map file &apos;{1}&apos; is invalid. It does not contain root element &apos;WITD&apos;. Please create a valid file by referring to the file schema in the help documents and try again..
        /// </summary>
        internal static string VstsNoWitd {
            get {
                return ResourceManager.GetString("VstsNoWitd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TF61020: The Work Item Type Definition file &apos;{0}&apos; specified in schema map file &apos;{1}&apos; is invalid. It does not contain element &apos;WORKITEMTYPE&apos; under &apos;WITD&apos; node. Please create a valid file by referring to the file schema in the help documents and try again..
        /// </summary>
        internal static string VstsNoWorkItemType {
            get {
                return ResourceManager.GetString("VstsNoWorkItemType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provisioning work item type &apos;{0}&apos; in Team Foundation.
        /// </summary>
        internal static string VstsSchemaImporting {
            get {
                return ResourceManager.GetString("VstsSchemaImporting", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TF61016: Unable to start migration. User &apos;{0}&apos; is not a member of &apos;Service Accounts&apos; group. It is required for the user running converter to be part of &apos;Service Accounts&apos; security group.&quot;.
        /// </summary>
        internal static string VstsUserNotInServiceAccounts {
            get {
                return ResourceManager.GetString("VstsUserNotInServiceAccounts", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Validating users in Team Foundation..
        /// </summary>
        internal static string VstsValidatingUsers {
            get {
                return ResourceManager.GetString("VstsValidatingUsers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TF61018: Unable to start migration. The name of the work item speficied in definition file &apos;{0}&apos; does not match with the TargetWIT &apos;{1}&apos; in the schema map file &apos;{2}&apos;. Please update the WORKITEMTYPE node of the corresponding work item type definition file or the TargetWIT attribute in the schema map file so that both are the same and try running the converter again..
        /// </summary>
        internal static string VstsWitMismatch {
            get {
                return ResourceManager.GetString("VstsWitMismatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TF61013: Unable to start migration. The converter could not provision the work item type specified in the file {0} because of the following error:
        ///{1}. Please fix the source of the error and try again..
        /// </summary>
        internal static string VstsWITProvisionFailed {
            get {
                return ResourceManager.GetString("VstsWITProvisionFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TF61014: Unable to start migration. The converter could not provision the work item type specified in the file {0} because of the following error at Line: {1} Col: {2}:
        ///Error: {3}. Please fix the source of the error and try again..
        /// </summary>
        internal static string VstsWITValidationFailed {
            get {
                return ResourceManager.GetString("VstsWITValidationFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Truncating field &apos;{0}&apos;, from &apos;{1}&apos; to &apos;{2}&apos;.
        /// </summary>
        internal static string WarningFieldTruncated {
            get {
                return ResourceManager.GetString("WarningFieldTruncated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Work Item could not be saved due to following error: {0}.
        /// </summary>
        internal static string WISaveFailed {
            get {
                return ResourceManager.GetString("WISaveFailed", resourceCulture);
            }
        }
    }
}
