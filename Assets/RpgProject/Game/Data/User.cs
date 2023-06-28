using System.IO;
using Newtonsoft.Json;
using RpgProject.Framework.Resource;
using UnityEngine;

namespace RpgProject.Game.Data
{
    // WARNING: change that after the save system is implemented
    public class User
    {
        private string LOCAL_USER_PATH;
        public UserData Values;
        public User(string userPath)
        {
            LOCAL_USER_PATH = !string.IsNullOrEmpty(userPath) ? userPath : Path.Combine(Application.persistentDataPath, "Local/user.json");
            Values = new UserData();
            Initialize();
        }

        public static T Load<T>(T bind, T defaultValue) { if(bind == null) return defaultValue; return bind; }

        public void Initialize()
        {
            UserData user = Files.Json<UserData>(LOCAL_USER_PATH);

            // INITIALIZING VALUES
            Values.DisplayName = Load<string>(user.DisplayName, "Guest");
            Values.Identifier = Load<string>(user.Identifier, "imtheguest");
            Values.Avatar = Load<string>(user.Avatar, "guest");

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
    }

    public class UserData
    {
        [JsonProperty("DisplayName")]
        public string DisplayName;

        [JsonProperty("Identifier")]
        public string Identifier;

        [JsonProperty("Avatar")]
        public string Avatar;
        
    }
}