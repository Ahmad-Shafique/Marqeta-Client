using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarqetaClient
{
    public class WriteToFile
    {
        private static WriteToFile instance;

        public static WriteToFile GetInstance()
        {
            if(instance == null)
            {
                instance = new WriteToFile();
            }
            return instance;
        }

        private WriteToFile()
        {

        }

        public bool WriteToNewFile(string FilePath, params string[] Text )
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@FilePath))
            {
                foreach (string line in Text)
                {
                    file.WriteLineAsync(line);
                }
            }

            return true;
        }

        public bool AppendToFile(string FilePath, params string[] Text)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@FilePath, true))
            {
                foreach(string line in Text)
                {
                    file.WriteLineAsync(line);
                }
            }

            return true;
        }

        public bool WriteObjectToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);

                return true;
            }
        }
    }
}
