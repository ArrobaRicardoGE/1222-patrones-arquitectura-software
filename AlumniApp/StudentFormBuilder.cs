using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Configuration;

namespace AlumniApp
{
    class StudentFormBuilder : FormBuilder
    {
        private DataGridView _grades;
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
            _grades = new();
            _grades.Dock = DockStyle.Fill;
            _grades.ReadOnly = true;
            _grades.ColumnCount = 5;
            _grades.Columns[0].Name = "Subject";
            _grades.Columns[1].Name = "Term 1";
            _grades.Columns[2].Name = "Term 2";
            _grades.Columns[3].Name = "Term 3";
            _grades.Columns[4].Name = "Average";

            float total = 0f; 
            foreach (var grade in grades)
            {
                float avg = (grade.Term1 + grade.Term2 + grade.Term3) / 3f;
                string[] r = { grade.Subject, grade.Term1.ToString(), grade.Term2.ToString(), grade.Term3.ToString(), avg.ToString("0.00") };
                _grades.Rows.Add(r);
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
            panel.Controls.Add(_grades, 0, 1);
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
                Text = "Save grades to file...",
                Size = new Size(100, 30),
            };
            b.Click += new EventHandler(DownloadGrades);

            b.Dock = DockStyle.Fill; 
            _form._layout.Controls.Add(b, 0, 2);
        }

        public void DownloadGrades(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new();
            DialogResult result = folder.ShowDialog();
            if (result != DialogResult.OK) return;

            GradesExporter exp = GradesExporterCreator.FactoryMethod();
            if (exp == null)
            {
                MessageBox.Show($"Unsupported file extension \"{ ConfigurationManager.AppSettings["format"] }\". Try again.");
                return;
            }
            string savepath = folder.SelectedPath + '\\' + _user.Username + "_grades";
            exp.SaveToFile(_grades, savepath);
            MessageBox.Show("File saved to " + savepath + exp.GetExtension()); 
        }
    }
}
