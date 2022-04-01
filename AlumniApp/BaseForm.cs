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
    /// Base class for the UI of students, teachers and supervisors. 
    /// Used by the builder to tie the possible final products. 
    /// </summary>
    class BaseForm : Form
    {
        public int width = 500, height = 500;
        public TableLayoutPanel _layout;
        public BaseForm() {
            ClientSize = new Size(width, height);
            _layout = new TableLayoutPanel();
            _layout.RowStyles.Add(new RowStyle(SizeType.Percent, 35f));
            _layout.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
            _layout.RowStyles.Add(new RowStyle(SizeType.Percent, 15f));
            _layout.Dock = DockStyle.Fill; 
            Controls.Add(_layout); 
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit(); 
        }
    }
}
