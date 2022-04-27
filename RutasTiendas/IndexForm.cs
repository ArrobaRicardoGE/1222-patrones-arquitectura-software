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
        public IndexForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
    }
}
