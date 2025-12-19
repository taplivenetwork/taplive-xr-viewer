using UnityEngine;
using System;

namespace TapLive.Utils
{
    /// <summary>
    /// Centralized logging with levels and filtering
    /// </summary>
    public static class DebugLogger
    {
        public enum LogLevel
        {
            Verbose = 0,
            Info = 1,
            Warning = 2,
            Error = 3,
            None = 4
        }

        private static LogLevel _currentLevel = LogLevel.Info;

        public static void SetLogLevel(LogLevel level)
        {
            _currentLevel = level;
            Debug.Log($"[DebugLogger] Log level set to: {level}");
        }

        public static void Verbose(string message, UnityEngine.Object context = null)
        {
            if (_currentLevel <= LogLevel.Verbose)
            {
                Debug.Log($"[VERBOSE] {message}", context);
            }
        }

        public static void Info(string message, UnityEngine.Object context = null)
        {
            if (_currentLevel <= LogLevel.Info)
            {
                Debug.Log($"[INFO] {message}", context);
            }
        }

        public static void Warning(string message, UnityEngine.Object context = null)
        {
            if (_currentLevel <= LogLevel.Warning)
            {
                Debug.LogWarning($"[WARNING] {message}", context);
            }
        }

        public static void Error(string message, UnityEngine.Object context = null)
        {
            if (_currentLevel <= LogLevel.Error)
            {
                Debug.LogError($"[ERROR] {message}", context);
            }
        }

        public static void Exception(Exception exception, UnityEngine.Object context = null)
        {
            if (_currentLevel <= LogLevel.Error)
            {
                Debug.LogException(exception, context);
            }
        }

        /// <summary>
        /// Log with timestamp
        /// </summary>
        public static void LogWithTime(string message, LogLevel level = LogLevel.Info)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
            string formattedMessage = $"[{timestamp}] {message}";
            
            switch (level)
            {
                case LogLevel.Verbose:
                    Verbose(formattedMessage);
                    break;
                case LogLevel.Info:
                    Info(formattedMessage);
                    break;
                case LogLevel.Warning:
                    Warning(formattedMessage);
                    break;
                case LogLevel.Error:
                    Error(formattedMessage);
                    break;
            }
        }
    }
}
