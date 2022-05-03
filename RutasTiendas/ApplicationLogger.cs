using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace RutasTiendas
{
    public class ApplicationLogger : Logger
    {
        private static Logger _instance = null;
        private static object _handle = new();

        ApplicationLogger() {
            _instance = null; 
        }
        
        public static Logger GetInstance()
        {
            lock (_handle)
            {
                if (_instance == null) _instance = new ApplicationLogger();
            }

            return _instance;
        }
        public override void LogEvent(string message) { }

        public static void AddFileSupport(string path)
        {
            if (_instance == null) GetInstance();
            _instance = new FileLogger(_instance, path);
        }
        
        public static void AddDataGridSupport(DataGridView grid)
        {
            if (_instance == null) GetInstance();
            _instance = new DataGridLogger(_instance, grid);
        }

        public static void AddTextBoxSupport(TextBox box)
        {
            if (_instance == null) GetInstance();
            _instance = new TextBoxLogger(_instance, box);
        }
    }
}
