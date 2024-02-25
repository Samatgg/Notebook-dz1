using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Drawing;

namespace Block
{
    public partial class Блокнот : Form
    {
        private string _openFile;
        public Блокнот()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод для шрифта - размер,курсив,жирность
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void шрифтToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FontDialog myFont = new FontDialog();
            if (myFont.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = myFont.Font;
            }
        }
        /// <summary>
        /// Метод для моздания нового окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void новоеОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
        /// <summary>
        /// Открытие файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog Fdialog = new OpenFileDialog();
            Fdialog.Filter = "all (*.*) |*.*";
            if(Fdialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(Fdialog.FileName);
                _openFile = Fdialog.FileName;
            }
        }
        /// <summary>
        /// Сохранение файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(_openFile, richTextBox1.Text);
            }
            catch(ArgumentException)
            {
                MessageBox.Show("save error");
            }
        }        
        /// <summary>
        /// Справка о блокноте
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Блокнот - v0.99.83\nВсе права защищены", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Палитра со цветами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void цветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog.Color;
            }
        }
        /// <summary>
        /// Метод для вырезки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }
        /// <summary>
        /// Метод для копирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }
        /// <summary>
        /// Метод для вставки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }
        /// <summary>
        /// Выход из блокнота
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Метод для печати 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument pDocument = new PrintDocument();
            pDocument.PrintPage += PrintPageH;
            PrintDialog pDialog = new PrintDialog();
            pDialog.Document = pDocument;
            if (pDialog.ShowDialog() == DialogResult.OK)
            {
                pDialog.Document.Print();
            }

        }
        public void PrintPageH(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, richTextBox1.Font, Brushes.Black, 0, 0);
        }
    }
}
