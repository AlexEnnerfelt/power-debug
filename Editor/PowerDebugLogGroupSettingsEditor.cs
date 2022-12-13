using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

static class PowerDebugLogGroupSettings
{
    [SettingsProvider]
    public static SettingsProvider CreateLoggingGroupsSettings() {
        var provider = new SettingsProvider("PowerDebug/Logging Groups", SettingsScope.User) {
            label = "Logging Groups",
            activateHandler = (searchContext, rootElement) => {

            },

            // Populate the search keywords to enable smart search filtering and label highlighting:
            keywords = new HashSet<string>(new[] { "Number", "Some String" })
        };

        return provider;
    }
}