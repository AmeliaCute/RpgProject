using RpgProject.Framework.Resource;
using RpgProject.Game.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace RpgProject.Game.Data
{
    public class User : DataStructure
    {
        public UserData Values;

        public User(string saveDir, string saveName)
        {
            LOCAL_SAVE_DIR = !string.IsNullOrEmpty(saveDir) ? saveDir : Path.Combine(Application.persistentDataPath, "Local/save");
            LOCAL_SAVE_NAME = !string.IsNullOrEmpty(saveName) ? saveName : "data_2.bin";
            Values = new UserData();
            Initialize();
        }

        public void Initialize()
        {
            UserData user = new();
            try 
            {
                user = Binaries.Read<UserData>(Path.Combine(LOCAL_SAVE_DIR,LOCAL_SAVE_NAME));
            }
            catch 
            { 
                if(!Directory.Exists(Path.Combine(LOCAL_SAVE_DIR)))
                    Directory.CreateDirectory(Path.Combine(LOCAL_SAVE_DIR));
                File.Create(Path.Combine(LOCAL_SAVE_DIR, LOCAL_SAVE_NAME)).Close();
            }

            // INITIALIZING VALUES
            Values.DisplayName = Load(user.DisplayName, "Guest");
            Values.Identifier = Load(user.Identifier, "imtheguest");
            Values.AvatarUrl = Load(user.AvatarUrl, "guest");
            Values.Banner = Load(user.Banner, "default");
            Values.Exp = Load(user.Exp, 0);
            Values.Level = Load(user.Level, 1);

            Save(Values);
        }

        public int CalculateExpNextLevel()
        {
            return Mathf.RoundToInt(100 * Mathf.Pow(1.5f, Values.Level));
        }
        public float NextLevelAdvancement()
        {
            return ((float)Values.Exp) / ((float)CalculateExpNextLevel());
        }

        public void AddExp(int exp)
        {
            if (exp > 0)
                Values.Exp += exp;
                
            CheckLevelCompletion();
        }

        public void AddLevel(int level)
        {
            if (level > 0 && Values.Level > 0)
            {
                Values.Level += level;
            }
        }

        public void ChangeDisplayName(string newName)
        {
            if(newName != Values.DisplayName)
            {
                Values.DisplayName = newName;
            }
        }

        public bool CheckLevelCompletion()
        {
            if(Values.Exp >= CalculateExpNextLevel())
            {
                Values.Exp -= CalculateExpNextLevel();
                Values.Level++;

                return true;
            }
            return false;
        }
    }

    [Serializable]
    public class UserData
    {
        public string DisplayName;
        public string Identifier;
        public string AvatarUrl;
        public string Banner;
        public int Exp;
        public int Level;
    }
}