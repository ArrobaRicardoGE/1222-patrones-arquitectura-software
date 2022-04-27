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
    public partial class RegisterOrderForm : Form
    {
        private Order o; 
        public RegisterOrderForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new()
            {
                Filter = "Codigo QR (*.jpg)|*.jpg",
            };
            if (file.ShowDialog() != DialogResult.OK) return;

            try
            {
                QRCodeGenerator qr = new IronBarCodeAdapter();
                o = qr.ReadQR(file.FileName);
                label2.Text = $"Store ID: {o.idStore}";
                label1.Text = $"Name: {o.storeName}";
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = true;
                button2.Enabled = true; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            o.ResetOrder(); 

            OrderCommand[] cmds = new OrderCommand[3];
            cmds[0] = new AddVegetableCommand(o, (int)numericUpDown1.Value);
            cmds[1] = new AddSodaCommand(o, (int)numericUpDown2.Value);
            cmds[2] = new AddBreadCommand(o, (int)numericUpDown3.Value); 

            foreach(var cmd in cmds)
                OrderInvoker.Execute(cmd);

            FolderBrowserDialog folder = new();
            DialogResult result = folder.ShowDialog();
            if (result != DialogResult.OK) return;
            o.ToQR(folder.SelectedPath);

            MessageBox.Show("Order sucessfully created"); 

        }
    }
}
