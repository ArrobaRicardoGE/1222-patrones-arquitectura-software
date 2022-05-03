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
    public partial class CreateRouteForm : Form
    {
        private RouteSimulator rs;
        private Logger logger; 
        public CreateRouteForm()
        {
            InitializeComponent();
            logger = ApplicationLogger.GetInstance(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog folder = new()
            {
                Multiselect = true,
                Filter = "QR code (*.jpg)|*.jpg",
            };
            DialogResult result = folder.ShowDialog();
            if (result != DialogResult.OK) return;
            rs = new RouteSimulator();
            QRCodeGenerator qr = new IronBarCodeAdapter();
            int totV = 0, totS = 0, totB = 0;
            float totR = 0f;
            dataGridView1.Rows.Clear(); 
            foreach(var filename in folder.FileNames)
            {
                var o = qr.ReadQR(filename);
                rs.AddOrder(o);
                AddRegisterToGrid(o); 
                totV += o.GetQuantityForID(1);
                totS += o.GetQuantityForID(2);
                totB += o.GetQuantityForID(3); 
                totR += o.GetRevenue();
            }
            label1.Text = $"Total: ${totR:0.00}";
            label2.Text = $"Total: {totB}";
            label3.Text = $"Total: {totS}";
            label4.Text = $"Total: {totV}";
            button2.Enabled = true;
            button3.Enabled = true;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            numericUpDown3.Enabled = true;
            button4.Enabled = false;
            logger.LogEvent($"Simulation started for {folder.FileNames.Length} stores"); 
        }

        private void AddRegisterToGrid(Order o, int priority = 0)
        {
            string[] r = { (priority == 0 ? "-" : priority + ""), o.idStore.ToString(), o.storeName, o.GetQuantityForID(1)+"",
                    o.GetQuantityForID(2)+"", o.GetQuantityForID(3)+"", $"${o.GetRevenue():0.00}"};
            dataGridView1.Rows.Add(r);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            label6.Text = $"Units: {numericUpDown1.Value * 95}";
            rs.SetTruckQuantity(1, (int)numericUpDown1.Value * 95);
            logger.LogEvent($"Added {numericUpDown1.Value} frozen vegetables trucks"); 
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            label8.Text = $"Units: {numericUpDown2.Value * 120}";
            rs.SetTruckQuantity(2, (int)numericUpDown2.Value * 120);
            logger.LogEvent($"Added {numericUpDown2.Value} soda trucks");
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            label10.Text = $"Units: {numericUpDown3.Value * 270}";
            rs.SetTruckQuantity(3, (int)numericUpDown3.Value * 270);
            logger.LogEvent($"Added {numericUpDown3.Value} bread trucks");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var rem = rs.SimulateRoute();
                string msg = $"Simulation ran successfully. Remainder products:\nFrozen vegetables: {rem[1]}\nSoda: {rem[2]}\nBread: {rem[3]}";
                MessageBox.Show(msg);
                logger.LogEvent(msg);
            }
            catch(Exception ex)
            {
                string msg = $"Simulation failed. Not enough supply for product {ex.Message}, try again"; 
                MessageBox.Show(msg);
                logger.LogEvent(msg); 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var orders = rs.GetRoute();
                dataGridView1.Rows.Clear();
                for(int i = 0; i < orders.Count; i++)
                    AddRegisterToGrid(orders[i], i + 1);
                button4.Enabled = true;
                MessageBox.Show("Route created");
                logger.LogEvent("Route created"); 
            }
            catch (Exception ex)
            {
                string msg = $"Unable to create route. Not enough supply for product {ex.Message}, try again";
                MessageBox.Show(msg);
                logger.LogEvent(msg); 
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new();
            DialogResult result = folder.ShowDialog();
            if (result != DialogResult.OK) return;

            TXTExporter.SaveToFile(dataGridView1, folder.SelectedPath + "\\route");

            string msg = $"Route saved in {folder.SelectedPath}\\route.csv"; 
            MessageBox.Show(msg);
            logger.LogEvent(msg); 
        }
    }
}
