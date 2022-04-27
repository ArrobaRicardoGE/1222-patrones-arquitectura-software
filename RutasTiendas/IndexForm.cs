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

        private void GenerateQRCode(object sender, EventArgs e)
        {
            //FolderBrowserDialog folder = new();
            //DialogResult result = folder.ShowDialog();
            //if (result != DialogResult.OK) return;

            //QRCodeGenerator qr = new IronBarCodeAdapter();
            //qr.GenerateQR(textBox.Text, folder.SelectedPath + '\\' + "qr_example3");
            Order o = new();
            o.ResetOrder();
            OrderCommand cmd = new AddVegetableCommand(o, 12);
            OrderCommand cmd2 = new AddVegetableCommand(o, 14); 
            OrderInvoker.Execute(cmd);
            MessageBox.Show(o.products[0].quantity + "");
            OrderInvoker.Execute(cmd2);
            MessageBox.Show(o.products[1].quantity + "");
            o.Undo();
            MessageBox.Show(o.products.Count + "");
            MessageBox.Show(o.products[0].quantity + "");
        }

        private void ReadQRCode(object sender, EventArgs e)
        {
            OpenFileDialog file = new()
            {
                Filter = "Codigo QR (*.jpg, *.png)|*.jpg;*.png",
            };
            if (file.ShowDialog() != DialogResult.OK) return;

            try
            {
                QRCodeGenerator qr = new IronBarCodeAdapter();
                MessageBox.Show("Result:\n" + qr.ReadQR(file.FileName));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
    }
}
