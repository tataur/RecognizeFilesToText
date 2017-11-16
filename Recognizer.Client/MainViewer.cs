using Recognizer.Library;
using System;

namespace Recognizer.Client
{
    public class MainViewer<T>
    {
        private readonly IForm<T> _form;
        private readonly IRecognizer<T> _recognizer;

        public MainViewer(IForm<T> form, IRecognizer<T> recognizer)
        {
            _form = form;
            _recognizer = recognizer;

            _form.FileOpenClick += _view_FileOpenClick;
        }

        private void _view_FileOpenClick(object sender, EventArgs e)
        {
            T filePath = _form.FilePath;
            string content = _recognizer.Recognize(filePath);
            _form.Content = content;
        }
    }
}
