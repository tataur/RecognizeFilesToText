using Recognizer.Library;
using System;

namespace Recognizer.Client
{
    public class MainViewer
    {
        private readonly IForm _form;
        private readonly IRecognizer _recognizer;

        public MainViewer(IForm form, IRecognizer recognizer)
        {
            _form = form;
            _recognizer = recognizer;

            _form.FileOpenClick += _view_FileOpenClick;
        }

        private void _view_FileOpenClick(object sender, EventArgs e)
        {
            string filePath = _form.FilePath;
            string content = _recognizer.Recognize(filePath);
            _form.Content = content;
        }
    }
}
