using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AlumniApp
{
    /// <summary>
    /// Login form. It is also the client for the builder
    /// </summary>
    class LoginForm : Form
    {
        private Field username, password;
        private Button login; 
        private static int width = 500, height = 500; 
        public LoginForm() {
            // Set size
            ClientSize = new Size(width, height);

            // Add fields
            Label title = new()
            {
                Dock = DockStyle.Top,
                Text = "AlumniApp",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Harlow Solid Italic", 32),
                Padding = new Padding(0, 50, 0, 0),
                Height = 100,
            };

            var panel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                Dock = DockStyle.Fill,
                AutoSize = true,
            };

            username = new Field("Username");
            password = new Field("Password", true);
            login = new Button
            {
                Text = "Login",
                Dock = DockStyle.Fill,
                Size = new Size(40, 40),
            };
            login.Click += new EventHandler(TryLogin);
            AcceptButton = login; 

            SuspendLayout();
            Controls.Add(title); 
            panel.Controls.Add(username);
            panel.Controls.Add(password);
            panel.WrapContents = false; 
            panel.Controls.Add(login);
            panel.Anchor = AnchorStyles.None;
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
            FormDirector director = new();
            FormBuilder builder = null ;
            
            if (user.Type == "student") builder = new StudentFormBuilder(user);
            if (user.Type == "teacher") builder = new TeacherFormBuilder(user);
            if (user.Type == "supervisor") builder = new SupervisorFormBuilder(user);

            director.Construct(builder);
            builder.GetResult().Show();
            Hide(); 
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit();
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
