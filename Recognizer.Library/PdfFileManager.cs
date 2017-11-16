using System;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace Recognizer.Library
{
    public class PdfFileManager : IRecognizer
    {
        public string Recognize(string filePath)
        {
            string resultText = "";
            var reader = new PdfReader(filePath);

            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                resultText += PdfTextExtractor.GetTextFromPage(reader, page);
            }
            reader.Close();
            return resultText;
        }
    }
}
