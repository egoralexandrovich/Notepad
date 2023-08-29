using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotepadC_
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Создаем метод VisitLink
        private void VisitLink()
        {
            // Изменяем цвет посещенной ссылки, программно 
            //обращаясь к свойству LinkVisited элемента LinkLabel 
            linkLabel1.LinkVisited = true;
            //Вызываем метод Process.Start method  для запуска браузера, 
            //установленного по умолчанию, и открытия ссылки
            System.Diagnostics.Process.Start("http://www.notepadcsharp.com");
        }
        private void linkLabel1_Click(object sender, EventArgs e)
        {
            //Добавляем блок для обработки исключений — по разным причинам 
            //пользователь может не получить доступа к ресурсу.
            try
            {
                //Вызываем метод VisitLink
                VisitLink();
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось открыть ссылку", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        //Создаем метод VisitLink для второй ссылки
        private void VisitLink2()
        {
            // Изменяем цвет посещенной ссылки, программно 
            //обращаясь к свойству LinkVisited элемента LinkLabel
            linkLabel2.LinkVisited = true;
            //Вызываем метод Process.Start method  для запуска браузера, 
            //установленного по умолчанию, и открытия ссылки
            System.Diagnostics.Process.Start("https://vk.com/egorikmagorik");
        }
        private void linkLabel2_Click(object sender, EventArgs e)
        {
            try
            {
                VisitLink2();
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось открыть ссылку", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}