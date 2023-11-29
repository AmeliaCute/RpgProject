using Newtonsoft.Json;
using RpgProject.Framework.Resource;
using UnityEngine;
using System.IO;

namespace RpgProject.Game.Data
{
    public class Settings
    {
        private string CONFIG_FILE_DIR;
        private string CONFIG_FILE_NAME = "settings.json";
        public RpgSettingsData Values;
        public Settings(string configPath)
        {
            CONFIG_FILE_DIR = !string.IsNullOrEmpty(configPath) ? configPath : Path.Combine(Application.persistentDataPath, "Local");
            Values = new RpgSettingsData();
            Initialize();
        }

        public void Save()
        {
            if(!Directory.Exists(Path.Combine(CONFIG_FILE_DIR)))
                Directory.CreateDirectory(Path.Combine(CONFIG_FILE_DIR));

            File.WriteAllText(Path.Combine(CONFIG_FILE_DIR, CONFIG_FILE_NAME), JsonConvert.SerializeObject(Values));
        }

        public static T Load<T>(T bind, T defaultValue) { try { if (bind.Equals(default(T)) || bind == null) return defaultValue; return bind; } catch { return defaultValue; } }

        public void Initialize()
        {
            RpgSettingsData config = new();
            try
            {
                config = Files.Json<RpgSettingsData>(Path.Combine(CONFIG_FILE_DIR, CONFIG_FILE_NAME));
            }
            catch
            {
                if(!Directory.Exists(Path.Combine(CONFIG_FILE_DIR)))
                {
                    Directory.CreateDirectory(Path.Combine(CONFIG_FILE_DIR));
                }
                File.Create(Path.Combine(CONFIG_FILE_DIR, CONFIG_FILE_NAME)).Close();
            }

            // INITIALIZING VALUES
            Values.VerbosityLevel = Load<int>(config.VerbosityLevel, 2);
            Values.Framerate = Load<int>(config.Framerate, 60);
            Values.InventoryKey = Load<int>(config.InventoryKey, 9);
            Values.BackgroundColor = Load<string>(config.BackgroundColor, "141414");
            Values.BackgroundAltColor = Load<string>(config.BackgroundAltColor, "1B1B1B");
            Values.ButtonColor = Load<string>(config.ButtonColor, "3A4750");
            Values.TabColor = Load<string>(config.TabColor, "EEEEEE");
            Values.TabAltColor = Load<string>(config.TabAltColor, "FFFFFF");
            
            Save();
        }
    }

    public class RpgSettingsData
    {
        [JsonProperty("VerbosityLevel")]
        public int VerbosityLevel;

        [JsonProperty("Framerate")]
        public int Framerate;

        [JsonProperty("InventoryKey")]
        public int InventoryKey;

        [JsonProperty("BackgroundColor")]
        public string BackgroundColor;

        [JsonProperty("BackgroundAltColor")]
        public string BackgroundAltColor;

        [JsonProperty("ButtonColor")]
        public string ButtonColor;

        [JsonProperty("TabColor")]
        public string TabColor;

        [JsonProperty("TabAltColor")]
        public string TabAltColor;
    }
}