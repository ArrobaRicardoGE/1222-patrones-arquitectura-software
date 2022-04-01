using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; 

namespace AlumniApp
{
    class TXTGradesExporter : GradesExporter
    {
        public override void SaveToFile(DataGridView data, string filename)
        {
            using(TextWriter tw = new StreamWriter($"{filename}.txt"))
            {
                for(int i = 0; i < data.Columns.Count; i++)
                {
                    tw.Write($"{data.Columns[i].Name}");
                    if (i != data.Columns.Count - 1)
                    {
                        tw.Write("|");
                    }
                }
                tw.WriteLine();
                for (int i = 0; i < data.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < data.Columns.Count; j++)
                    {
                        tw.Write($"{data.Rows[i].Cells[j].Value}");

                        if (j != data.Columns.Count - 1)
                        {
                            tw.Write(",");
                        }
                    }
                    tw.WriteLine();
                }
            }
        }

        public override string GetExtension()
        {
            return ".txt"; 
        }
    }
}
