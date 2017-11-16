using Recognizer.Library;
using System;
using System.Windows.Forms;

namespace Recognizer.Client
{
    public partial class RecognizerForm : Form, IForm<string>
    {
        public RecognizerForm()
        {
            InitializeComponent();
            button_selectFile.Click += buttonSelectFile_Click;
        }

        public string FilePath { get { return textBox_openFile.Text; } }

        public string Content { get { return textBox_content.Text; } set { textBox_content.Text = value; } }

        public event EventHandler FileOpenClick;

        public void buttonSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Текстовые файлы|*.txt|PDF файлы|*.pdf|Изображения|*.jpg,*.jpeg,*bmp,*.png|Все файлы|*.*";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                textBox_openFile.Text = dialog.FileName;
                CheckFileType(dialog);
                
                if (FileOpenClick != null)
                {
                    FileOpenClick(this, EventArgs.Empty);
                }
            }
        } 

        private void CheckFileType(OpenFileDialog file)
        {
            if (file.FileName.Contains(".pdf"))
            {
                PdfFileManager pdfRecognizer = new PdfFileManager();
                CreateMainViewer(pdfRecognizer);
            }
            else if (file.FileName.Contains(".txt"))
            {
                TextFileManager txtRecognizer = new TextFileManager();
                CreateMainViewer(txtRecognizer);
            }
        }

        private void CreateMainViewer(IRecognizer<string> recognizer)
        {
            var viewer = new MainViewer<string>(this, recognizer);
        }
    }

    public interface IForm<T>
    {
        T FilePath { get; }
        string Content { get; set; }
        event EventHandler FileOpenClick;
    }
}
