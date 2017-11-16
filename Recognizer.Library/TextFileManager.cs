using System.IO;
using System.Text;

namespace Recognizer.Library
{
    public class TextFileManager : IRecognizer<string>
    {
        private readonly Encoding _encoding = Encoding.GetEncoding(1251);

        public string Recognize(string filePath)
        {
            string file = File.ReadAllText(filePath, _encoding);
            return file;
        }
    }
}
