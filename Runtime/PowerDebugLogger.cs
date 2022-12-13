using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PowerDebug
{
    
    public static PowerDebugSettings Settings { get { return PowerDebugSettings.Instance; } }

    public static void Log(object message, Object context = null, LogThreshold logLevel = LogThreshold.Low) {
        Log(message, context, (int)logLevel);
    }
    public static void Log(object message, Object context = null, int threshold = 1) {
        if (threshold <= Settings.Number) {
            var msg = Settings.ProcessLogMessage(new LogMessage((string)message, context));
            Debug.Log(msg, context);
        }
    }
}

public struct LogMessage
{
    public LogMessage (string _message, Object _context) {
        message = _message;
        context = _context;
    }
    public string message;
    public Object context;
}

public enum LogThreshold : int { 
    Low = 1, 
    Medium = 500, 
    High = 1000
}