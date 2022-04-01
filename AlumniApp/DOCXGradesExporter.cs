using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop;
using System.Windows.Forms;

namespace AlumniApp
{
    class DOCXGradesExporter : GradesExporter
    {
        public override void SaveToFile(DataGridView data, string filename)
        {
            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

            //Start Word and create a new document.
            Microsoft.Office.Interop.Word._Application oWord;
            Microsoft.Office.Interop.Word._Document oDoc;
            oWord = new Microsoft.Office.Interop.Word.Application();
            oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
            ref oMissing, ref oMissing);

            //Insert a 3 x 5 table, fill it with data, and make the first row
            //bold and italic.
            Microsoft.Office.Interop.Word.Table oTable;
            Microsoft.Office.Interop.Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = oDoc.Tables.Add(wrdRng, data.Rows.Count + 1, data.Columns.Count, ref oMissing, ref oMissing);
            oTable.Range.ParagraphFormat.SpaceAfter = 6;

            oTable.Rows[1].Range.Font.Bold = 1;
            oTable.Rows[1].Range.Font.Italic = 1;

            for (int i = 0; i < data.Columns.Count; i++)
                oTable.Cell(1, i + 1).Range.Text = data.Columns[i].Name; 

            for (int i = 1; i <= data.Rows.Count; i++)
                for (int j = 0; j < data.Columns.Count; j++)
                    oTable.Cell(i + 1, j + 1).Range.Text = $"{data.Rows[i - 1].Cells[j].Value}";

            oDoc.SaveAs2(filename + ".docx");

        }

        public override string GetExtension()
        {
            return ".docx";
        }
    }
}
