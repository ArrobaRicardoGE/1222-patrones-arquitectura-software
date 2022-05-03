using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace RutasTiendas
{
    public class DataGridLogger : LoggerDecorator
    {
        private DataGridView grid; 
        public DataGridLogger(Logger logger, DataGridView _grid) : base(logger)
        {
            grid = _grid; 
        }

        public override void LogEvent(string message)
        {
            string[] r = { DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), message }; 
            base.LogEvent(message);
            grid.Rows.Add(r); 
        }
    }
}
