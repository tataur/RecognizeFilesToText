using System;

namespace Recognizer.Client
{
    public interface IForm<T>
    {
        T FilePath { get; }
        string Content { get; set; }
        event EventHandler FileOpenClick;
    }
}
