using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using RpgProject.Framework.Resource;
using UnityEngine;

namespace RpgProject.Game.Data
{
    // WARNING: change that after the save system is implemented
    public class User
    {
        private readonly string LOCAL_USER_PATH;
        public UserData Values;
        public User(string userPath)
        {
            LOCAL_USER_PATH = !string.IsNullOrEmpty(userPath) ? userPath : Path.Combine(Application.persistentDataPath, "Local/user.json");
            Values = new UserData();
            Initialize();
        }

        public static T Load<T>(T bind, T defaultValue)
        {
            if (bind == null || EqualityComparer<T>.Default.Equals(bind, default))
                return defaultValue;
            return bind;
        }

        public void Initialize()
        {
            UserData user = new();
            try
            {
                user = Files.Json<UserData>(LOCAL_USER_PATH);
            }
            catch
            {
                File.Create(LOCAL_USER_PATH).Close();
            }

            // INITIALIZING VALUES
            Values.DisplayName = Load(user.DisplayName, "Guest");
            Values.Identifier = Load(user.Identifier, "imtheguest");
            Values.Avatar = Load(user.Avatar, "guest");
            Values.Exp = Load(user.Exp, 0);
            Values.Level = Load(user.Level, 1);

            Save();
        }
        public void Save()
        {
            if (!Directory.Exists(Path.GetDirectoryName(LOCAL_USER_PATH)))
                Directory.CreateDirectory(Path.GetDirectoryName(LOCAL_USER_PATH));

            if(!File.Exists(LOCAL_USER_PATH))
                File.Create(LOCAL_USER_PATH).Close();

            File.WriteAllText(LOCAL_USER_PATH, JsonConvert.SerializeObject(Values));
        }

        public int CalculateExpNextLevel()
        {
            return Mathf.RoundToInt(100 * Mathf.Pow(1.5f, Values.Level));
        }
        public float NextLevelAdvancement()
        {
            return ((float) Values.Exp) / ((float) CalculateExpNextLevel());
        }
    }

    public class UserData
    {
        [JsonProperty("DisplayName")]
        public string DisplayName;

        [JsonProperty("Identifier")]
        public string Identifier;

        [JsonProperty("Avatar")]
        public string Avatar;

        [JsonProperty("Exp")]
        public int Exp;

        [JsonProperty("Level")]
        public int Level;
    }
}