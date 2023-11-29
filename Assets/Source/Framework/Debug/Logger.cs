using System.IO;
using System;
using UnityEngine;

namespace RpgProject.Framework.Debug
{
    public class Logger
    {
        private readonly string LOGGER_NAME;
        private readonly int VERBOSITY;
        private readonly string LOG_FILENAME;
        private StreamWriter log;

        public Logger(string name, int verbosityLevel = 1)
        {
            LOGGER_NAME = name;
            VERBOSITY = verbosityLevel;
            LOG_FILENAME = DateTime.Now.ToString("yyyy-MM-dd.HH-mm-ss.fffffff");
            CreateNewFile();
        }

        private void CreateNewFile()
        {
            string folderPath = Path.Combine(Application.persistentDataPath, "Logs");
            string filePath = Path.Combine(folderPath, LOG_FILENAME + ".log");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            log = File.CreateText(filePath);
            log.WriteLine($"RPG PROJECT → {LOG_FILENAME}");
            log.WriteLine($"VERBOSITY LEVEL → {VERBOSITY}");
        }

        private void PrintLog(string message, string prefix)
        {
            string formattedMessage = $"{prefix} > {DateTime.Now.ToString("HH:mm:ss")} [{LOGGER_NAME}] {message}";
            UnityEngine.Debug.Log(formattedMessage);
            log?.WriteLine(formattedMessage);
        }

        public void Warning(string message)
        {
            if (VERBOSITY >= 2)
                PrintLog(message, "⚠️");
        }

        public void Log(string message)
        {
            if (VERBOSITY >= 3)
                PrintLog(message, "👀");
        }

        public void Error(string message)
        {
            if (VERBOSITY >= 1)
                PrintLog(message, "🚫");
        }

        public void Passed(string message)
        {
            if (VERBOSITY >= 3)
                PrintLog(message, "✅");
        }

        public void LogWithCustomPrefix(string message, string prefix)
        {
            if (VERBOSITY >= 1)
                PrintLog(message, prefix);
        }

        public StreamWriter GetWrittenFile()
        {
            return log;
        }
    }
}