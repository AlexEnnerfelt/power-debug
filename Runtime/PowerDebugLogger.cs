using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Internal;
using Object = UnityEngine.Object;

public static class PowerDebug
{
    //private static PowerDebugSettings settings;
    public static PowerDebugSettings Settings {
        [HideInCallstack]
        get { return PowerDebugSettings.Instance; }
    }

    [HideInCallstack]
    internal static void PowerLogMessage(object message, Object context, int threshold) {
        if (threshold <= Settings.Number) {
            if (context == null) {
                unityLogger.Log(LogType.Log, message);
            }
            else {
                var msg = (object)Settings.ProcessLogMessage(new LogMessage((string)message, context));
                unityLogger.Log(LogType.Log, msg, context);
            }
        }
    }

    [HideInCallstack]
    internal static void PowerLogError(object message, Object context, int threshold) { }

    [HideInCallstack]
    internal static void PowerLogWarning(object message, Object context, int threshold) { }

    public static bool isDebugBuild {
        [HideInCallstack]
        get { return Debug.isDebugBuild; }
    }

    public static bool developerConsoleVisible {
        [HideInCallstack]
        get { return Debug.developerConsoleVisible; }
        [HideInCallstack]
        set { Debug.developerConsoleVisible = value; }
    }

    
    public static ILogger unityLogger {
        [HideInCallstack]
        get {
            return Debug.unityLogger;
            return Debug.unityLogger;
        }
    }
    
    [HideInCallstack]
    public static void Log(object message) {
        PowerLogMessage(message, null, Settings.DefaultThreshold);
    }
    [HideInCallstack]
    public static void Log(object message, Object context, LogThreshold threshold = LogThreshold.Low) {
        PowerLogMessage(message, context, (int)threshold);
    }
    [HideInCallstack]
    public static void Log(object message, Object context, int threshold) {
        PowerLogMessage(message, context, threshold);
    }
    [HideInCallstack]
    public static void LogFormat(string format, params object[] args) {
        unityLogger.LogFormat(LogType.Log, format, args);
    }
    [HideInCallstack]
    public static void LogFormat(Object context, string format, params object[] args) {
        unityLogger.LogFormat(LogType.Log, context, format, args);
    }
    [HideInCallstack]
    public static void LogFormat(LogType logType, LogOption logOptions, Object context, string format, params object[] args) {
        Debug.LogFormat(logType, logOptions, context, format, args);
    }
    [HideInCallstack]
    public static void LogError(object message) {
        unityLogger.Log(LogType.Error, message);
    }
    [HideInCallstack]
    public static void LogError(object message, Object context) {
        unityLogger.Log(LogType.Error, message, context);
    }
    [HideInCallstack]
    public static void LogErrorFormat(string format, params object[] args) {
        unityLogger.LogFormat(LogType.Error, format, args);
    }
    [HideInCallstack]
    public static void LogErrorFormat(Object context, string format, params object[] args) {
        unityLogger.LogFormat(LogType.Error, context, format, args);
    }

    [HideInCallstack]
    public static void ClearDeveloperConsole() {
        Debug.ClearDeveloperConsole();
    }

    [HideInCallstack]
    public static void LogException(Exception exception) {
        Debug.LogException(exception);
    }
    [HideInCallstack]
    public static void LogException(Exception exception, Object context) {
        Debug.LogException(exception, context);
    }
    [HideInCallstack]
    public static void LogWarning(object message) {
        unityLogger.Log(LogType.Warning, message);
    }

    [HideInCallstack]
    public static void LogWarning(object message, Object context) {
        unityLogger.Log(LogType.Warning, message, context);
    }
    [HideInCallstack]
    public static void LogWarningFormat(string format, params object[] args) {
        unityLogger.LogFormat(LogType.Warning, format, args);
    }
    [HideInCallstack]
    public static void LogWarningFormat(Object context, string format, params object[] args) {
        unityLogger.LogFormat(LogType.Warning, context, format, args);
    }
    [HideInCallstack]
    public static void Assert(bool condition) {
        if (!condition) {
            unityLogger.Log(LogType.Assert, "Assertion failed");
        }
    }
    [HideInCallstack]
    public static void Assert(bool condition, Object context) {
        if (!condition) {
            unityLogger.Log(LogType.Assert, (object)"Assertion failed", context);
        }
    }
    [HideInCallstack]
    public static void Assert(bool condition, object message) {
        if (!condition) {
            unityLogger.Log(LogType.Assert, message);
        }
    }
    [HideInCallstack]
    public static void Assert(bool condition, string message) {
        if (!condition) {
            unityLogger.Log(LogType.Assert, message);
        }
    }
    [HideInCallstack]
    public static void Assert(bool condition, object message, Object context) {
        if (!condition) {
            unityLogger.Log(LogType.Assert, message, context);
        }
    }
    [HideInCallstack]
    public static void Assert(bool condition, string message, Object context) {
        if (!condition) {
            unityLogger.Log(LogType.Assert, (object)message, context);
        }
    }
    [HideInCallstack]
    public static void AssertFormat(bool condition, string format, params object[] args) {
        if (!condition) {
            unityLogger.LogFormat(LogType.Assert, format, args);
        }
    }
    [HideInCallstack]
    public static void AssertFormat(bool condition, Object context, string format, params object[] args) {
        if (!condition) {
            unityLogger.LogFormat(LogType.Assert, context, format, args);
        }
    }
    [HideInCallstack]
    public static void LogAssertion(object message) {
        unityLogger.Log(LogType.Assert, message);
    }
    [HideInCallstack]
    public static void LogAssertion(object message, Object context) {
        unityLogger.Log(LogType.Assert, message, context);
    }
    [HideInCallstack]
    public static void LogAssertionFormat(string format, params object[] args) {
        unityLogger.LogFormat(LogType.Assert, format, args);
    }
    [HideInCallstack]
    public static void LogAssertionFormat(Object context, string format, params object[] args) {
        unityLogger.LogFormat(LogType.Assert, context, format, args);
    }
}

public enum LogThreshold : int
{
    Low = 1,
    Medium = 500,
    High = 1000
}
public struct LogMessage
{
    public LogMessage(string _message, Object _context) {
        message = _message;
        context = _context;
    }
    public string message;
    public Object context;
}