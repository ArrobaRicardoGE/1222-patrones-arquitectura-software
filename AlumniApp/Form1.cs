using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlumniApp
{
    public partial class Form1 : Form
    {
        public Button button1;
        public Form1()
        {
            InitializeComponent();
            button1 = new Button
            {
                Size = new Size(120, 40),
                Location = new Point(30, 30),
                Text = "Click me",
            };
            Controls.Add(button1);
            button1.Click += new EventHandler(button1_Click);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello world"); 
        }

    }
}
