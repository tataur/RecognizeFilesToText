using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognizer.Library
{
    public class TextFileManager : IRecognizer
    {
        private readonly Encoding _encoding = Encoding.GetEncoding(1251);

        public string Recognize(string filePath)
        {
            string file = File.ReadAllText(filePath, _encoding);
            return file;
        }
    }
}
