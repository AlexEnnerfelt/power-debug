using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class PowerDebug
{
    static PowerDebugSettings Settings;

    public static void Init(PowerDebugSettings settings) {
        Settings = settings;
    }

    public static void Log(object message, Object context = null, LogThreshold logLevel = LogThreshold.Low) {
        Log(message, context, (int)logLevel);
    }

    public static void Log(object message, Object context, int threshold) {

        if (threshold <= Settings.Number) {
            Debug.Log(message, context);
        }
    }
}

public enum LogThreshold : int { 
    Low = 1, 
    Medium = 500, 
    High = 1000
}