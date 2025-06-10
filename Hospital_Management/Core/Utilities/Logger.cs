using System;
using System.IO;
using System.Text;

namespace Hospital_Management.Core.Utilities
{
    public static class Logger
    {
        private static readonly string LogDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
        private static readonly string LogFile = Path.Combine(LogDirectory, $"hospital_log_{DateTime.Now:yyyy-MM-dd}.txt");

        static Logger()
        {
            // Create logs directory if it doesn't exist
            if (!Directory.Exists(LogDirectory))
            {
                Directory.CreateDirectory(LogDirectory);
            }
        }

        public static void LogInfo(string message)
        {
            Log("INFO", message);
        }

        public static void LogError(string message, Exception? exception = null)
        {
            var errorMessage = exception != null 
                ? $"{message} - Exception: {exception.Message}\nStackTrace: {exception.StackTrace}"
                : message;
            Log("ERROR", errorMessage);
        }

        public static void LogWarning(string message)
        {
            Log("WARNING", message);
        }

        private static void Log(string level, string message)
        {
            try
            {
                var logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}";
                File.AppendAllText(LogFile, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // If logging fails, we can't log the error, so we'll just ignore it
                Console.WriteLine($"Failed to write to log file: {ex.Message}");
            }
        }
    }
} 