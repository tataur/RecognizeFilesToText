using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognizer.Library
{
    public interface IRecognizer<T>
    {
        string Recognize(T filePath); 
    }
}
