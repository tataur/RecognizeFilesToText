using Recognizer.Library;
using System;
using System.IO;
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

        public string FilePath { get { return textBox_openFilePath.Text; } }

        public string Content { get { return textBox_content.Text; } set { textBox_content.Text = value; } }

        public event EventHandler FileOpenClick;

        public void buttonSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Текстовые файлы|*.txt|PDF файлы|*.pdf|Изображения|*.jpg,*.jpeg,*bmp,*.png|Все файлы|*.*";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                textBox_openFilePath.Text = dialog.FileName;
                string extension = Path.GetExtension(dialog.FileName);
                CheckFileType(extension);

                FileOpenClick?.Invoke(this, EventArgs.Empty);
            }
        } 

        private void CheckFileType(string extension)
        {
            if (extension == ".pdf")
            {
                PdfFileManager pdfRecognizer = new PdfFileManager();
                CreateMainViewer(pdfRecognizer);
            }
            else if (extension == ".txt")
            {
                TextFileManager txtRecognizer = new TextFileManager();
                CreateMainViewer(txtRecognizer);
            }
            else if (extension == ".jpg" || extension == ".jpeg" || extension == ".bmp" || extension == ".png")
            {
                ImageFileManager imageRecognizer = new ImageFileManager();
                CreateMainViewer(imageRecognizer);
            }
            else
            {
                MessageBox.Show("Неизвестный файл");
            }
        }

        private void CreateMainViewer(IRecognizer<string> recognizer)
        {
            var viewer = new MainViewer<string>(this, recognizer);
        }
    }
}
