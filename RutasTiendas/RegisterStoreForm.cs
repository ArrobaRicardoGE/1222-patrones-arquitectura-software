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
using System.Text.RegularExpressions;

namespace RutasTiendas
{
    public partial class RegisterStoreForm : Form
    {
        public RegisterStoreForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Enter a valid name");
                return;
            }

            FolderBrowserDialog folder = new();
            DialogResult result = folder.ShowDialog();
            if (result != DialogResult.OK) return;
            string path = folder.SelectedPath;
            int lastID = 0;

            foreach(var filename in Directory.GetFiles(path))
            {
                if (!Regex.IsMatch(filename, @"order_\d\d.jpg")) continue;
                var val = Int32.Parse(filename.Substring(filename.Length - 6, 2));
                lastID = Math.Max(lastID, val); 
            }

            Order o = new();
            o.storeName = textBox1.Text;
            o.idStore = lastID + 1;

            QRCodeGenerator qr = new IronBarCodeAdapter();
            qr.GenerateQR(o, path + $"\\order_{o.idStore.ToString().PadLeft(2, '0')}");
            MessageBox.Show("Store registered. QR code saved in: " + path);
            Close(); 
        }
    }
}
