
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;
using UnityEngine.UIElements;
using UAssembly = UnityEditor.Compilation.Assembly;
using Assembly = System.Reflection.Assembly;
using System.Collections.Immutable;

// Register a SettingsProvider using UIElements for the drawing framework:
static class PowerDebugSettingsEditor
{
    public const string k_MyCustomSettingsPath = "Assets/Resources/PowerDebugSettings.asset";
    internal static PowerDebugSettings GetOrCreateSettings() {
        var settings = AssetDatabase.LoadAssetAtPath<PowerDebugSettings>(k_MyCustomSettingsPath);
        if (settings == null) {
            settings = ScriptableObject.CreateInstance<PowerDebugSettings>();
            AssetDatabase.CreateAsset(settings, k_MyCustomSettingsPath);
            AssetDatabase.SaveAssets();
        }
        return settings;
    }
    internal static SerializedObject GetSerializedSettings() {
        return new SerializedObject(GetOrCreateSettings());
    }

    [SettingsProvider]
    public static SettingsProvider CreateMyCustomSettingsProvider() {
        var provider = new SettingsProvider("PowerDebug/Logging Level", SettingsScope.User) {
            label = "Logging Level",
            activateHandler = (searchContext, rootElement) => {
                var settings = GetOrCreateSettings();
                //var serializedSettings = GetSerializedSettings();
                PowerDebug.Init(settings);
                var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Packages/com.ennerfelt.powerdebug/Editor/UIElements/settings_ui.uss");

                var visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Packages/com.ennerfelt.powerdebug/Editor/UIElements/logging_level_settings_menu.uxml");
                var rootFromUxml = visualTreeAsset.Instantiate();

                rootElement.Add(rootFromUxml);
                rootElement.styleSheets.Add(styleSheet);

                var levelSlider = rootElement.Q<SliderInt>("loglevel-slider");
                levelSlider.value = settings.Number;

                levelSlider.RegisterValueChangedCallback(level => {
                    settings.Number = level.newValue;
                });
            },

            // Populate the search keywords to enable smart search filtering and label highlighting:
            keywords = new HashSet<string>(new[] { "Number", "Some String" })
        };

        return provider;
    }

}

