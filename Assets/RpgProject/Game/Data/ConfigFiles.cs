using Newtonsoft.Json;
using RpgProject.Framework.Resource;
using UnityEngine;
using System.IO;

namespace RpgProject.Game.Data 
{
    public class Settings
    {
        private string CONFIG_PATH;
        public RpgSettingsData Values;
        public Settings(string configPath)
        {
            CONFIG_PATH = !string.IsNullOrEmpty(configPath) ? configPath : Path.Combine(Application.persistentDataPath, "rpgsettings.json");
            Values = new RpgSettingsData();
            Initialize();
        }

        public void Save()
        {
            if(!File.Exists(CONFIG_PATH))
                File.Create(CONFIG_PATH).Close();

            File.WriteAllText(CONFIG_PATH, JsonConvert.SerializeObject(Values));
        }

        public static T Load<T>(T bind, T defaultValue) { if(bind.Equals(default(T))) return defaultValue; return bind; }

        public void Initialize()
        {
            RpgSettingsData config = new RpgSettingsData();
            try
            {
                config = Files.Json<RpgSettingsData>(CONFIG_PATH);
            }
            catch
            {
                File.Create(CONFIG_PATH).Close();
            }

            // INITIALIZING VALUES
            Values.VerbosityLevel = Load<int>(config.VerbosityLevel, 2);


            Save();
        }

        
    }

    public class RpgSettingsData
    {
        [JsonProperty("VerbosityLevel")]
        public int VerbosityLevel;

    }
}