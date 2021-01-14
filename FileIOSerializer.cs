using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace sandboxCS
{
    internal abstract class FileIOSerializer
    {
        internal const string ERR_SAVE = "Save error";
        internal const string ERR_LOAD = "Load error";
        //------------------------------------------------binary serialization, save, load
        internal static void Save(object saveableObj, string path)
        {
            var binFormatter = new BinaryFormatter();
            using (var fStream = new FileStream(path, FileMode.Create))
            {
                binFormatter.Serialize(fStream, saveableObj);
            }
        }
        internal static void Save(object saveableObj, Stream fs)
        {
            var binFormatter = new BinaryFormatter();
            try
            {
                binFormatter.Serialize(fs, saveableObj);
            }
            catch { throw new System.Exception(ERR_SAVE); }
        }
        //--------------------------------------------------------------------------
        internal static void Load<T>(ref T loadableObj, string path) where T : class
        {
            var binFormatter = new BinaryFormatter();
            using (var fStream = new FileStream(path, FileMode.Open))
            {
                loadableObj = binFormatter.Deserialize(fStream) as T;
            }
        }
        internal static void Load<T>(ref T loadableObj, Stream fs) where T : class
        {
            var binFormatter = new BinaryFormatter();
            try
            {
                loadableObj = binFormatter.Deserialize(fs) as T;
            }
            catch { throw new System.Exception(ERR_LOAD); }
        }
        //---------------------------------------------------------------------------
    }
}