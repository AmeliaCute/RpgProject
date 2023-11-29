using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace RpgProject.Framework.Resource
{
    public class Binaries
    {
        public static T Read<T>(string path)
        {
            T obj;
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                obj = (T)binaryFormatter.Deserialize(fileStream);
                fileStream.Close();
            }

            return obj;
        }

        public static void Write<T>(string path, T obj)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, obj);
                fileStream.Close();
            }
        }
    }
}