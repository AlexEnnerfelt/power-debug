using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class PowerDebugSettingsEditor
{
    static PowerDebugSettingsEditor() {
        GetOrCreateSettings();
    }

    
    internal static PowerDebugSettings GetOrCreateSettings() {
        var settings = AssetDatabase.LoadAssetAtPath<PowerDebugSettings>(PowerDebugSettings.k_MyCustomSettingsPath);
        if (settings == null) {
            settings = ScriptableObject.CreateInstance<PowerDebugSettings>();
            Directory.CreateDirectory(PowerDebugSettings.k_MyCustomSettingsPath);
            AssetDatabase.CreateAsset(settings, PowerDebugSettings.k_MyCustomSettingsPath);
            AssetDatabase.SaveAssets();
        }
        return settings;
    }
    internal static SerializedObject GetSerializedSettings() {
        return new SerializedObject(GetOrCreateSettings());
    }

}
