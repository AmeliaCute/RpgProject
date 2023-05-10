using System.IO;
using System;
using UnityEngine;
using System.Collections;

namespace RpgProject.Framework.Debug
{
    public class Logger
    {
        private string LOGGER_NAME;
        private int VERBOSITY;
        private string LOG_Filename;

        private StreamWriter log = null;

        public Logger(string name)
        {
            LOGGER_NAME = name;
            VERBOSITY = 1;
            LOG_Filename = DateTime.Now.ToString("yyyy-MM-dd.HH-mm-ss.fffffff");
            RpgClass.instance.StartCoroutine(createNewFile());
        }

        public Logger(string name, int verbositylevel)
        {
            LOGGER_NAME = name;
            VERBOSITY = verbositylevel;
            LOG_Filename = DateTime.Now.ToString("yyyy-MM-dd.HH-mm-ss.fffffff");
            RpgClass.instance.StartCoroutine(createNewFile());
        }

        private IEnumerator createNewFile()
        {
            string folderpath = Application.persistentDataPath+"/Logs";
            string filepath = folderpath+"/"+LOG_Filename+".log";
            if(!Directory.Exists(Application.persistentDataPath+"/Logs"))
                Directory.CreateDirectory(Application.persistentDataPath+"/Logs");
            
            if(!File.Exists(filepath))
            {
                log = File.CreateText(filepath);
                log.WriteLine("RPG PROJECT → "+LOG_Filename);
                log.WriteLine("VERBOSITY LEVEL → "+VERBOSITY);
            }
            else 
                yield return 1;

            yield return 0;
        }

        public void Warning(string mes)
        {
            if(VERBOSITY >= 2)
                RpgClass.instance.StartCoroutine(print("⚠️ > "+DateTime.Now.ToString("HH:mm:ss")+" ["+LOGGER_NAME+"] "+mes));
        }

        public void Log(string mes)
        {
            if(VERBOSITY >= 3)
                RpgClass.instance.StartCoroutine(print("👀 > "+DateTime.Now.ToString("HH:mm:ss")+" ["+LOGGER_NAME+"] "+mes));
        }

        public void Error(string mes)
        {
            if(VERBOSITY >= 1)
                RpgClass.instance.StartCoroutine(print("🚫 > "+DateTime.Now.ToString("HH:mm:ss")+" ["+LOGGER_NAME+"] "+mes));
        }

        public void Passed(string mes)
        {
            if(VERBOSITY >= 3)
                RpgClass.instance.StartCoroutine(print("✅ > "+DateTime.Now.ToString("HH:mm:ss")+" ["+LOGGER_NAME+"] "+mes));
        }

        public void LogWithCustomPrefix(string mes, string pref)
        {
            if(VERBOSITY >= 3)
                RpgClass.instance.StartCoroutine(print(pref+" > "+DateTime.Now.ToString("HH:mm:ss")+" ["+LOGGER_NAME+"] "+mes));
        }

        public StreamWriter getWritedFile()
        {
            return log;
        }

        private IEnumerator print(string x)
        {
            UnityEngine.Debug.Log(x);
            log.WriteLine(x);
            yield return null;
        }
    }
}