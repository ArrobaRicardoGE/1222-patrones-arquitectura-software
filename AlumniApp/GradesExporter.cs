using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AlumniApp
{
    /// <summary>
    /// Defines a common interface for grade exporters. Used by the factory method to abstract the creation. 
    /// </summary>
    abstract class GradesExporter
    {
        /// <summary>
        /// Exports the fiven DataGridView to a file. It will create it in the provided path. 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="filename"></param>
        public abstract void SaveToFile(DataGridView data, string filename);
        public abstract string GetExtension(); 
    }
}
