﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MadniPharmacy.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.;Initial Catalog=pharmacy;Integrated Security=True")]
        public string pharmacyConnectionString {
            get {
                return ((string)(this["pharmacyConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.;Initial Catalog=\"C:\\USERS\\SUFYAN AHMED\\ONEDRIVE\\DESKTOP\\MADNIPHARMA" +
            "CY\\MADNIPHARMACY\\BIN\\DEBUG\\PHARMACY.MDF\";Integrated Security=True")]
        public string C__USERS_SUFYAN_AHMED_ONEDRIVE_DESKTOP_MADNIPHARMACY_MADNIPHARMACY_BIN_DEBUG_PHARMACY_MDFConnectionString {
            get {
                return ((string)(this["C__USERS_SUFYAN_AHMED_ONEDRIVE_DESKTOP_MADNIPHARMACY_MADNIPHARMACY_BIN_DEBUG_PHAR" +
                    "MACY_MDFConnectionString"]));
            }
        }
    }
}
