using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace NotepadC_
{
    public partial class DopForm : Form
    {
        public DopForm()
        {
            InitializeComponent();
        }
        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        Timer timer;

        public string filename;
        public bool IsSaved = false;
        private void DopForm_Load(object sender, EventArgs e)
        {

        }
        public DopForm(int number)
        {
            InitializeComponent();
            Text = "Document" + number.ToString();

            infoLabel = new ToolStripLabel();
            infoLabel.Text = "Текущие дата и время:";
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();

            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);

            timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        public void Open()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            filename = openFileDialog.FileName;
            string fileText = File.ReadAllText(filename);
            richTextBox1.Text = fileText;
            MessageBox.Show("Файл открыт", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void Save()
        {
            if(filename == null ^ filename == "")
            {
                if(saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filename = saveFileDialog1.FileName;
                    File.WriteAllText(filename, richTextBox1.Text);
                    MessageBox.Show("Файл сохранен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                File.WriteAllText(filename, richTextBox1.Text);
                MessageBox.Show("Файл сохранен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void SaveAs()
        {
            string filename1 = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                filename1 = saveFileDialog.FileName;
            else
                return;
            try
            {
                StreamWriter writer = new StreamWriter(filename1);
                writer.Write(richTextBox1.Text);
                filename = filename1;
                writer.Close();
                MessageBox.Show("Файл сохранен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Не удалось сохранить файл", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void Cut()
        { // Вырезание текста
            if(richTextBox1.TextLength > 0)
                richTextBox1.Cut();
        }
        public void Copy()
        { // Копирование текста
            if (richTextBox1.TextLength > 0)
                richTextBox1.Copy();
        }
        public void Paste()
        { // Копирование текста
            if (richTextBox1.Text.Length > 0)
                richTextBox1.Paste();
        }
        public void Delete()
        { // Удаление текста
            richTextBox1.SelectedText = "";
        }
        public void SelectAll()
        { // Выделение текста
            if (richTextBox1.TextLength > 0)
                richTextBox1.SelectAll();
        }
        public new void Font()
        { // Работа с шрифтом
            fontDialog1.ShowDialog();
            richTextBox1.Font = fontDialog1.Font;
        }
        public void Color()
        { // Работа с цветом формы
            colorDialog1.ShowDialog();
            richTextBox1.BackColor = colorDialog1.Color;
        }

        public void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        { // Контекстное меню при нажатии на правую кнопку мыши
            if (e.Button == MouseButtons.Right)
                richTextBox1.ContextMenuStrip = contextMenuStrip1;
        }

        private void cmsCut_Click(object sender, EventArgs e)
        { // Вырезание текста
            Cut();
        }

        private void cmsCopy_Click(object sender, EventArgs e)
        { // Копирование текста
            Copy();
        }

        private void cmsPaste_Click(object sender, EventArgs e)
        { // Вставка текста
            Paste();
        }

        private void cmsDelete_Click(object sender, EventArgs e)
        { // Удаление текста
            Delete();
        }

        private void cmsSelectAll_Click(object sender, EventArgs e)
        { // Выделение текста
            SelectAll();
        }

        private void DopForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Если переменная IsSaved имеет значение false, т. е. документ пытаются закрыть и он не сохранен
            if (IsSaved == false)
                //Появляется диалоговое окно, предлагающее сохранить документ.
                //Если была нажата  кнопка Yes, вызываем метод Save
                if (MessageBox.Show("Вы хотите сохранить изменения в " + this.filename + "?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    this.Save();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            sAmountofSymbols.Text = "Количество символов: " + richTextBox1.Text.Length.ToString();//выводим текст и считываем количество символов в документе
        }
    }
}