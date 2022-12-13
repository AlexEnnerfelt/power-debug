using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDebugSettings : ScriptableObject
{
    public const string k_MyCustomSettingsPath = "Assets/Resources/Settings/PowerDebugSettings.asset";
    public const string k_SettingsFileName = "/Settings/PowerDebugSettings.asset";
    public static PowerDebugSettings Instance { get; private set; }
    
    private void OnEnable() {
        Instance = this;
    }

    [field: SerializeField]
    public int Number { get; set; } = 1500;
    public int DefaultThreshold = 1;
    public LogGroupList logGroupList;
    
    public string ProcessLogMessage(LogMessage logMessage) {
        if (logMessage.context == null) {
            return logMessage.message;
        }
        var grp = logGroupList.IsTypeSpecifiedInGroup(logMessage.context.GetType().FullName);

        if (grp != null) {
            return grp.ApplyRulest(logMessage.message);
        }
        else {
            return logMessage.message;
        }
    }

    [Serializable]
    public class LogGroupList
    {
        public LogGroup[] customLogGroups;
        
        public LogGroup IsTypeSpecifiedInGroup(string typeName) {
            if (customLogGroups.Length > 0) {
                foreach (var item in customLogGroups) {
                    if (item.Contains(typeName)) {
                        return item;
                    }
                }
            }
            return null;
        }
    }

    [Serializable]
    public class LogGroup {
        public bool hasPrefix;
        public CustomTag prefixTag;
        public List<string> typesInGroup;

        public bool Contains(string typeName) { 
            return typesInGroup.Contains(typeName);
        }
        public string ApplyRulest(string input) {
            string output = input;
            if (hasPrefix) {
                output = $"{prefixTag.GetTag()} {input}";
            }
            return output;
        }
    }
    [Serializable]
    public class CustomTag {
        public string tag = null;
        public Color color;
        public bool isBold;

        public string GetTag() {
            var tag = isBold ? $"<b>{this.tag}</b>" : this.tag;
            tag = $"<color={color.GetHexcode()}>{tag}</color>"; 
            return tag;
        }
    }
}