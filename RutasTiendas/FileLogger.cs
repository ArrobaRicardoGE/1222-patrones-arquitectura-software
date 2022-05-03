using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 

namespace RutasTiendas
{
    public class FileLogger : LoggerDecorator
    {
        private string path; 
        public FileLogger(Logger logger, string _path) : base(logger)
        {
            path = _path; 
        }

        public override void LogEvent(string message)
        {
            string log = $"\n{DateTime.Now:MM/dd/yyyy HH:mm:ss} - {message}"; 
            base.LogEvent(message);
            File.AppendAllText(path, log); 
        }
    }
}
