using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

static class PowerDebugLogThresholdEditor
{
    [SettingsProvider]
    public static SettingsProvider CreateLogThresholdSettings() {
        var provider = new SettingsProvider("PowerDebug/Log Threshold", SettingsScope.User) {
            label = "Log Threshold",
            activateHandler = (searchContext, rootElement) => {
                var settings = PowerDebugSettingsEditor.GetOrCreateSettings();
                //var serializedSettings = GetSerializedSettings();
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

