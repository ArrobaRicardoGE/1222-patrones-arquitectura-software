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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GenerateQRCode(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new();
            DialogResult result = folder.ShowDialog();
            if (result != DialogResult.OK) return;

            QRCodeGenerator qr = new IronBarCodeAdapter();
            qr.GenerateQR(textBox.Text, folder.SelectedPath + '\\' + "qr_example2"); 
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
    }
}
