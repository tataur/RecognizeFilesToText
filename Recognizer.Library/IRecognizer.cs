namespace Recognizer.Library
{
    public interface IRecognizer<T>
    {
        string Recognize(T filePath); 
    }
}
