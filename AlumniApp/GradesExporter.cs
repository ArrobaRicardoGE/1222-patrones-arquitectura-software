using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AlumniApp
{
    abstract class GradesExporter
    {
        public abstract void SaveToFile(DataGridView data, string filename);
        public abstract string GetExtension(); 
    }
}
