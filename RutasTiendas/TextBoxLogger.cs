using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace RutasTiendas
{
    public class TextBoxLogger : LoggerDecorator
    {
        private TextBox box;
        public TextBoxLogger(Logger logger, TextBox _box) : base(logger)
        {
            box = _box; 
        }

        public override void LogEvent(string message)
        {
            string log = $"\r\n{DateTime.Now:MM/dd/yyyy HH:mm:ss} - {message}";
            base.LogEvent(message);
            box.Text += log;
        }
    }
}
