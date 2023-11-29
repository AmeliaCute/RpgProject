using System.Collections.Generic;
using System.IO;
using RpgProject.Framework.Resource;

namespace RpgProject.Game.Structure
{
    public class DataStructure
    {
        public string LOCAL_SAVE_DIR;
        public string LOCAL_SAVE_NAME = "data_tmp.bin";

        public T Load<T>(T bind, T defaultValue)
        {
            if (bind == null || EqualityComparer<T>.Default.Equals(bind, default))
                return defaultValue;
            return bind;
        }

        public void Save<T>(T Values)
        {
            if(!Directory.Exists(Path.Combine(LOCAL_SAVE_DIR)))
                Directory.CreateDirectory(Path.Combine(LOCAL_SAVE_DIR));

            Binaries.Write(Path.Combine(LOCAL_SAVE_DIR, LOCAL_SAVE_NAME), Values);
        }
    }
}