

using System.IO;
using UnityEngine;

namespace RpgProject.Framework.Resource
{
    public class Files
    {
        public static T Json<T>(string path)
        {
            TextAsset jsonFile = null;
            jsonFile = new TextAsset(File.ReadAllText(path));

            UnityEngine.Debug.Log(jsonFile.text);
            if (jsonFile != null)
            {
                T loadedResource = JsonUtility.FromJson<T>(jsonFile.text);
                if (loadedResource != null)
                {
                    return loadedResource;
                }
                else
                    RpgClass.RPGLOGGER?.Error("Failed to load resource: " + path + " cause it is not valid json");
            }
            else
                RpgClass.RPGLOGGER?.Error("Failed to load resource: " + path + " cause it does not exist");

            return default(T);
        }

    }
}
