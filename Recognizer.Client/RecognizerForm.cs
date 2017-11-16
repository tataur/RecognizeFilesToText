using System;
using System.Windows.Forms;

namespace Recognizer.Client
{
    public partial class RecognizerForm : Form, IForm
    {
        public RecognizerForm()
        {
            InitializeComponent();
            button_selectFile.Click += buttonSelectFile_Click;
        }

        void button_openFile_Click(object sender, EventArgs e)
        {
            if(FileOpenClick != null)
            {
                FileOpenClick(this, EventArgs.Empty);
            }
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
                if(FileOpenClick != null)
                {
                    FileOpenClick(this, EventArgs.Empty);
                }
            }
        } 
    }

    public interface IForm
    {
        string FilePath { get; }
        string Content { get; set; }
        event EventHandler FileOpenClick;
    }
}
