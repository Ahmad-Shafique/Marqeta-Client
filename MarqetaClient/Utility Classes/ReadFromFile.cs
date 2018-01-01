using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarqetaClient
{
    public class ReadFromFile
    {
        private static ReadFromFile instance;

        public static ReadFromFile GetInstance()
        {
            if (instance == null)
            {
                instance = new ReadFromFile();
            }
            return instance;
        }

        private ReadFromFile()
        {

        }

        public string ReadFileAsOneString(string FilePath)
        {
            return System.IO.File.ReadAllText(@FilePath);
        }

        public string[] ReadFileAsLines(string FilePath)
        {
            return System.IO.File.ReadAllLines(@FilePath);
        }

        public T ReadObjectFromBinaryFile<T>(string FilePath)
        {
            using (Stream stream = File.Open(FilePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }


        }
    }
}
