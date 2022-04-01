using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AlumniApp
{
    class SupervisorFormBuilder : FormBuilder
    {
        public SupervisorFormBuilder(User user) : base(user) { }
        public override void SetTitle()
        {
            _form.Text = "AlumniApp: Supervisor"; 
        }
        public override void BuildGrades()
        {
            return; 
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
            string[] r0 = { "Supervisor's Name:", info.Name };
            string[] r1 = { "Year of birth:", info.BirthYear.ToString() };
            string[] r2 = { "Place of birth:", info.Hometown };

            data.Rows.Add(r0);
            data.Rows.Add(r1);
            data.Rows.Add(r2);
            data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            Label title = new()
            {
                Dock = DockStyle.Fill,
                Text = "Supervisor's Information",
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

        public override void BuildDownloadGrades()
        {
            return;
        }
    }
}
