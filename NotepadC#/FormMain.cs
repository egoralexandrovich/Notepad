using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NotepadC_
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            mnuSave.Enabled = false;
        }
        int number = 1;

        private void mnuNew_Click(object sender, EventArgs e)
        { // Добавление новой формы
            DopForm dopForm = new DopForm(number);
            number++;
            dopForm.MdiParent = this;//помещаем дочернюю форму в родительскую
            dopForm.Show();
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        { // Открытие файла
            DopForm dopForm = (DopForm)(this.ActiveMdiChild);
            dopForm.Open();
            mnuSave.Enabled = true;
        }

        private void mnuSave_Click(object sender, EventArgs e)
        { // Сохранение файла
            DopForm dopForm = (DopForm)this.ActiveMdiChild;
            dopForm.Save();
            mnuSave.Enabled = true;
            dopForm.IsSaved = true;
        }
        private void mnuSaveAs_Click(object sender, EventArgs e)
        { // Сохранить как
            DopForm dopForm = (DopForm)(this.ActiveMdiChild);
            dopForm.SaveAs();
            mnuSave.Enabled = true;
            dopForm.IsSaved = true;
        }

        private void mnuClose_Click(object sender, EventArgs e)
        { // Закрытие формы
            if(this.MdiChildren.Count() > 0)//избегаем ошибки, когда нет открытых форм
                this.ActiveMdiChild.Close();
        }

        private void mnuCloseAll_Click(object sender, EventArgs e)
        { // Закрытие всех форм
            foreach(DopForm dopForm in this.MdiChildren)
                this.ActiveMdiChild.Close();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        { // Выход из приложения
            Application.Exit();
        }

        private void mnuCut_Click(object sender, EventArgs e)
        { // Вырезание текста
            DopForm dopForm = (DopForm)(this.ActiveMdiChild);
            dopForm.Cut();
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        { // Копирование текста
            DopForm dopForm = (DopForm)(this.ActiveMdiChild);
            dopForm.Copy();
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        { // Вставка текста
            DopForm dopForm = (DopForm)(this.ActiveMdiChild);
            dopForm.Paste();
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        { // Удаление текста
            DopForm dopForm = (DopForm)(this.ActiveMdiChild);
            dopForm.Delete();
        }

        private void mnuSelectAll_Click(object sender, EventArgs e)
        { // Выделение текста
            DopForm dopForm = (DopForm)(this.ActiveMdiChild);
            dopForm.SelectAll();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        { // Шрифт
            DopForm dopForm = (DopForm)(this.ActiveMdiChild);
            dopForm.Font();
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        { // Цвет формы
            DopForm dopForm = (DopForm)(this.ActiveMdiChild);
            dopForm.Color();
        }

        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        { // Информация о программе
            About about = new About();
            about.Show();
        }

        private void mnuArrangeIcons_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void mnuCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuTileHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuTileVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void tsNew_Click(object sender, EventArgs e)
        { // Новый документ
            DopForm dopForm = new DopForm(number);
            number++;
            dopForm.MdiParent = this;//помещаем дочернюю форму в родительскую
            dopForm.Show();
        }

        private void tsOpen_Click(object sender, EventArgs e)
        { // Открытие документа
            DopForm dopForm = (DopForm)(this.ActiveMdiChild);
            dopForm.Open();
            mnuSave.Enabled = true;
        }

        private void tsSave_Click(object sender, EventArgs e)
        { // Сохранение документа
            DopForm dopForm = (DopForm)this.ActiveMdiChild;
            dopForm.Save();
            mnuSave.Enabled = true;
            dopForm.IsSaved = true;
        }

        private void tsSaveAs_Click(object sender, EventArgs e)
        { // Сохранить как
            DopForm dopForm = (DopForm)(this.ActiveMdiChild);
            dopForm.SaveAs();
            mnuSave.Enabled = true;
            dopForm.IsSaved = true;
        }

        private void tsCut_Click(object sender, EventArgs e)
        { // Вырезание текста
            DopForm dopForm = (DopForm)(this.ActiveMdiChild);
            dopForm.Cut();
        }

        private void tsCopy_Click(object sender, EventArgs e)
        { // Копирование текста
            DopForm dopForm = (DopForm)(this.ActiveMdiChild);
            dopForm.Copy();
        }

        private void tsPaste_Click(object sender, EventArgs e)
        { // Вставка текста
            DopForm dopForm = (DopForm)(this.ActiveMdiChild);
            dopForm.Paste();
        }
    }
}