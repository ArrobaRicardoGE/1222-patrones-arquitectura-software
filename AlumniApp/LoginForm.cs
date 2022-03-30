using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AlumniApp
{
    class LoginForm : Form
    {
        private Field username, password;
        private Button login; 
        private static int width = 500, height = 500; 
        public LoginForm() {
            // Set size
            ClientSize = new Size(width, height);

            // Add fields
            var panel = new FlowLayoutPanel();
            panel.FlowDirection = FlowDirection.TopDown;
            panel.Dock = DockStyle.Fill;

            username = new Field("Username");
            password = new Field("Password", true);
            login = new Button
            {
                Text = "Login",
                Dock = DockStyle.Fill,
            };
            login.Click += new EventHandler(TryLogin);
            AcceptButton = login; 

            SuspendLayout();
            panel.Controls.Add(username);
            panel.Controls.Add(password);
            panel.Controls.Add(login);
            panel.Anchor = AnchorStyles.None; panel.Anchor = AnchorStyles.None;
            panel.Location = new Point(width / 2 - panel.Width / 2, height / 2 - panel.Height / 2);

            Controls.Add(panel);

            Text = "AlumniApp Login";
            ResumeLayout(false);
            PerformLayout();
        }

        private void TryLogin(object sender, EventArgs e)
        {
            if(username.textBox.Text == String.Empty || password.textBox.Text == String.Empty)
            {
                MessageBox.Show("Please, enter you username and password.");
                return; 
            }

            Database db = new JSONDataSourceAdapter();
            User user; 
            try
            {
                user = db.GetUserByUsername(username.textBox.Text); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return; 
            }

            if(user.Password != password.textBox.Text)
            {
                MessageBox.Show("Incorrect password. Try again.");
                return;
            }
            MessageBox.Show("Login!");
        }

    }

    class Field : FlowLayoutPanel
    {
        public Label label;
        public TextBox textBox;

        public Field(string labelText, bool isPassword = false)
            : base()
        {
            AutoSize = true;

            label = new Label
            {
                Text = labelText,
                AutoSize = true,
                Anchor = AnchorStyles.Left,
                TextAlign = ContentAlignment.MiddleLeft
            };

            Controls.Add(label);

            textBox = new TextBox();
            if (isPassword) textBox.PasswordChar = '*'; 

            Controls.Add(textBox);
        }
    }
}
