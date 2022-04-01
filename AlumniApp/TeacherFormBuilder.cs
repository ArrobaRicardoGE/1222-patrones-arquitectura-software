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
    /// Form builder for the users labeled as teachers
    /// </summary>
    class TeacherFormBuilder : FormBuilder
    {
        public TeacherFormBuilder(User user) : base(user) { }

        public override void SetTitle()
        {
            _form.Text = "AlumniApp: Teacher";
        }

        public override void BuildGrades()
        {
            // Pool data 
            var grades = _db.GetGradesByTeacherID(_user.UserID);

            // Show
            DataGridView data = new();
            data.Dock = DockStyle.Fill;
            data.ReadOnly = true;
            data.ColumnCount = 6;
            data.Columns[0].Name = "Student's Name";
            data.Columns[1].Name = "Subject";
            data.Columns[2].Name = "Term 1";
            data.Columns[3].Name = "Term 2";
            data.Columns[4].Name = "Term 3";
            data.Columns[5].Name = "Average";
            data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (var grade in grades)
            {
                float avg = (grade.Term1 + grade.Term2 + grade.Term3) / 3f;
                var student_info = _db.GetInfoByUserID(grade.StudentID); 
                string[] r = { student_info.Name, grade.Subject, grade.Term1.ToString(), grade.Term2.ToString(), grade.Term3.ToString(), avg.ToString("0.00") };
                data.Rows.Add(r);
            }
            Label title = new()
            {
                Dock = DockStyle.Fill,
                Text = "Grades",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12),
            };

            TableLayoutPanel panel = new();
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 80f));
            panel.Controls.Add(title, 0, 0);
            panel.Controls.Add(data, 0, 1);
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
            string[] r0 = { "Teacher's Name:", info.Name };
            string[] r1 = { "Year of birth:", info.BirthYear.ToString() };
            string[] r2 = { "Place of birth:", info.Hometown };

            data.Rows.Add(r0);
            data.Rows.Add(r1);
            data.Rows.Add(r2);
            data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            Label title = new()
            {
                Dock = DockStyle.Fill,
                Text = "Teacher's Infomation",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12),
            };

            TableLayoutPanel panel = new();
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 80f));
            panel.Controls.Add(title, 0, 0);
            panel.Controls.Add(data, 0, 1);
            panel.Dock = DockStyle.Fill;
            _form._layout.Controls.Add(panel, 0, 0);
        }

        public override void BuildDownloadGrades() { }
    }
}
