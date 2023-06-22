using Newtonsoft.Json;

namespace RpgProject.Game.Data 
{
    public class RpgSettingsData
    {
        [JsonProperty("VerbosityLevel")]
        public int VerbosityLevel;

    }
    
    public enum RpgSettings
    {
        VerbosityLevel,
    }
}