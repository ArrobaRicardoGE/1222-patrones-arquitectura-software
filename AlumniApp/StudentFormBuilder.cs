using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AlumniApp
{
    class StudentFormBuilder : FormBuilder
    {
        public StudentFormBuilder(User user) : base(user) { }

        public override void SetTitle()
        {
            _form.Text = "AlumniApp: Student";
        }

        public override void BuildGrades()
        {
            // Pool data
            var grades = _db.GetGradesByStudentID(_user.UserID);

            // Show
            DataGridView data = new();
            data.Dock = DockStyle.Fill;
            data.ReadOnly = true;
            data.ColumnCount = 5;
            data.Columns[0].Name = "Subject";
            data.Columns[1].Name = "Term 1";
            data.Columns[2].Name = "Term 2";
            data.Columns[3].Name = "Term 3";
            data.Columns[4].Name = "Average";

            float total = 0f; 
            foreach (var grade in grades)
            {
                float avg = (grade.Term1 + grade.Term2 + grade.Term3) / 3f;
                string[] r = { grade.Subject, grade.Term1.ToString(), grade.Term2.ToString(), grade.Term3.ToString(), avg.ToString("0.00") };
                data.Rows.Add(r);
                total += avg; 
            }
            Label title = new();
            title.Dock = DockStyle.Fill;
            title.Text = "Grades";

            Label average = new Label
            {
                Dock = DockStyle.Fill,
                Text = "Average: " + (total / grades.Count).ToString("0.00")
            };

            TableLayoutPanel panel = new();
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 15f));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 75f));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f)); 
            panel.Controls.Add(title, 0, 0);
            panel.Controls.Add(data, 0, 1);
            panel.Controls.Add(average, 0, 2);
            panel.Dock = DockStyle.Fill;
            _form._layout.Controls.Add(panel, 0, 1);  
        }

        public override void BuildInfo()
        {
            // Pool data
            var info = _db.GetInfoByUserID(_user.UserID);

            // Show data
            DataGridView data = new();
            data.ReadOnly = true; 
            data.ColumnCount = 2;
            data.Dock = DockStyle.Fill;
            data.Columns[0].Name = "Parameter";
            data.Columns[1].Name = "Value";
            string[] r0 = { "Student's Name:", info.Name };
            string[] r1 = { "Career:", info.Career };
            string[] r2 = { "Year of birth:", info.BirthYear.ToString() };
            string[] r3 = { "Place of birth:", info.Hometown };

            data.Rows.Add(r0);
            data.Rows.Add(r1);
            data.Rows.Add(r2);
            data.Rows.Add(r3);

            Label title = new();
            title.Dock = DockStyle.Fill;
            title.Text = "Student's information";

            TableLayoutPanel panel = new();
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 80f));
            panel.Controls.Add(title, 0, 0);
            panel.Controls.Add(data, 0, 1);
            panel.Dock = DockStyle.Fill;
            _form._layout.Controls.Add(panel, 0, 0);
        }

        public override void BuildDownloadGrades()
        {
            var b = new Button
            {
                Text = "Download Grades",
                Size = new Size(100, 30),
            };
            b.Click += new EventHandler(DownloadGrades);

            b.Dock = DockStyle.Fill; 
            _form._layout.Controls.Add(b, 0, 2);
        }

        public void DownloadGrades(object sender, EventArgs e)
        {
            MessageBox.Show("Downloading..."); 
        }
    }
}
