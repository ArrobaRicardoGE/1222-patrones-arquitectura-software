using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RutasTiendas
{
    public partial class LoggerForm : Form
    {
        private DataGridView grid;
        private TextBox box; 
        public LoggerForm(DataGridView _grid, TextBox _box)
        {
            InitializeComponent();
            grid = _grid;
            box = _box;
            tableLayoutPanel1.Controls.Add(grid, 1, 0);
            tableLayoutPanel1.Controls.Add(box, 1, 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new()
            {
                Filter = "Log file (*.txt)|*.txt",
            };
            if (file.ShowDialog() != DialogResult.OK) return;

            ApplicationLogger.AddFileSupport(file.FileName);

            MessageBox.Show("Sending log to file"); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ApplicationLogger.AddDataGridSupport(grid);
            MessageBox.Show("Sending log to data grid");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ApplicationLogger.AddTextBoxSupport(box);
            MessageBox.Show("Sending log to text box");
        }

        private void LoggerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide(); 
        }
    }
}
