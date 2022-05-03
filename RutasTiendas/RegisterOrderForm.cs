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
        private string originalFilename;
        private Logger logger; 
        public RegisterOrderForm()
        {
            InitializeComponent();
            logger = ApplicationLogger.GetInstance(); 
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
                originalFilename = file.FileName; 
                o = qr.ReadQR(originalFilename);
                label2.Text = $"Store ID: {o.idStore}";
                label1.Text = $"Name: {o.storeName}";
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = true;
                button2.Enabled = true;
                logger.LogEvent($"Create order for store \"{o.storeName}\" (ID {o.idStore})");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                logger.LogEvent($"ERROR: {ex.Message}"); 
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
            OrderCommand toQR = new CreateQRCommand(o, folder.SelectedPath, originalFilename);
            OrderInvoker.Execute(toQR); 

            MessageBox.Show("Order sucessfully created");
            logger.LogEvent($"Finalize order for store \"{o.storeName}\" (ID {o.idStore})");

            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OrderCommand cmd = new UndoCommand(o);
            OrderInvoker.Execute(cmd); 
            MessageBox.Show("Order reverted");
            logger.LogEvent($"Revert order for store \"{o.storeName}\" (ID {o.idStore})");
            button3.Enabled = false;  
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            logger.LogEvent($"Changed frozen vegetables amount for new order to {numericUpDown1.Value}"); 
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            logger.LogEvent($"Changed sodas amount for new order to {numericUpDown2.Value}");
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            logger.LogEvent($"Changed bread amount for new order to {numericUpDown3.Value}");
        }
    }
}
