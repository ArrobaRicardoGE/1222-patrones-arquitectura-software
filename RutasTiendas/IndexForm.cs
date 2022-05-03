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
    public partial class IndexForm : Form
    {
        public TextBox textBoxLogger;
        public DataGridView dataGridLogger;
        private LoggerForm lf; 
        public IndexForm()
        {
            InitializeComponent();
            textBoxLogger = new()
            {
                Multiline = true,
                ReadOnly = true,
                Size = new Size(300, 200),
                Dock = DockStyle.Fill,
            };
            dataGridLogger = new()
            {
                ReadOnly = true,
                ColumnCount = 2,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Dock = DockStyle.Fill,
                Size = new Size(300, 200),
            };
            dataGridLogger.Columns[0].Name = "Time";
            dataGridLogger.Columns[1].Name = "Event";
            lf = new(dataGridLogger, textBoxLogger);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var logger = ApplicationLogger.GetInstance();
            logger.LogEvent("hola"); 
            RegisterStoreForm form = new();
            form.Show(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegisterOrderForm form = new();
            form.Show(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreateRouteForm form = new();
            form.Show(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lf.Show(); 
        }
    }
}
