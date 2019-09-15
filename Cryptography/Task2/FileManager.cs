using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    public static class FileManager
    {
        public static string Read(string fileName)
        {
            StringBuilder result = new StringBuilder();

            using (StreamReader file = new StreamReader(fileName, Encoding.Default))
            {
                result.Append(file.ReadToEnd());
            }

            return result.ToString();
        }

        public static void Write(string fileName, string information)
        {
            using (StreamWriter file = new StreamWriter(fileName, true, Encoding.Default))
            {
                file.WriteLine(information);
            }
        }
    }
}
