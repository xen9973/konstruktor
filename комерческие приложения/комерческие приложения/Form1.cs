using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace комерческие_приложения
{
  
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            richTextBox1.AllowDrop = true;
            richTextBox1.DragEnter += RichTextBox_DragEnter;
            richTextBox1.DragDrop += RichTextBox_DragDrop;
            richTextBox1.MouseDown += RichTextBox_MouseDown;
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            toolStripComboBox1.Items.AddRange(FontFamily.Families.Select(f => f.Name).ToArray());
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
           var saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Word document(*.docx)|*.docx|PDF document(*.pdf)|*.pdf|All files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            //System.IO.File.WriteAllText(filename, textBox1.Text);
            MessageBox.Show("Файл сохранен");
        }


        private void распечататьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region Printer Selection
            PrintDialog printDlg = new PrintDialog();
            #endregion
            #region Create Document
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Print Document";
            printDoc.PrintPage += printDoc_PrintPage;
            printDlg.Document = printDoc;
            #endregion
            if (printDlg.ShowDialog() == DialogResult.OK)
                printDoc.Print();
        }
        void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(this.richTextBox1.Text, this.richTextBox1.Font, Brushes.Black, 10, 25);
        }

        private void отправитьПоEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Создание приложения Outlook
            Outlook.Application outlookApp = new Outlook.Application();

            // Создание нового элемента сообщения
            Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);

            // Установка предварительных значений (опционально)
            mailItem.Subject = "Тема письма";
            mailItem.Body = "Текст письма";

            // Открытие окна сообщения
            mailItem.Display(true); // true означает, что окно будет модальным

            // Пользователь сможет выбрать получателей, редактировать письмо и отправить его вручную
        }
        // Обработчик события DragEnter для RichTextBox

        private void RichTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy; // Устанавливаем эффект копирования
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        // Обработчик события DragDrop для RichTextBox
        private void RichTextBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (var file in files)
                {
                    if (File.Exists(file) && IsImageFile(file))
                    {
                        InsertImage(file);
                    }
                }
            }
        }

        // Обработчик события MouseDown для RichTextBox
        private void RichTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var position = richTextBox1.GetPositionFromCharIndex(richTextBox1.GetCharIndexFromPosition(e.Location));
                int index = richTextBox1.GetCharIndexFromPosition(e.Location);

                // Проверяем, есть ли изображение в позиции курсора
                if (richTextBox1.GetCharIndexFromPosition(e.Location) != -1)
                {
                    // Удаляем изображение при клике правой кнопкой мыши
                    richTextBox1.SelectedText = ""; // Удаляем выделение
                    richTextBox1.SelectionStart = index;
                    richTextBox1.SelectionLength = 1;
                    richTextBox1.SelectedText = ""; // Удаляем изображение
                }
            }
        }

        // Метод для вставки изображения в RichTextBox
        private void InsertImage(string filePath)
        {
            Image image = Image.FromFile(filePath);
            Clipboard.SetImage(image); // Копируем изображение в буфер обмена
            richTextBox1.Paste(); // Вставляем изображение в RichTextBox
        }

        // Метод для проверки, является ли файл изображением
        private bool IsImageFile(string filePath)
        {
            string[] extensions = { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };
            return Array.Exists(extensions, ext => filePath.EndsWith(ext, StringComparison.OrdinalIgnoreCase));
        }
    }
}
          
