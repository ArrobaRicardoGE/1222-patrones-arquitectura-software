using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RutasTiendas
{
    public class LoggerDecorator : Logger
    {
        private Logger wrappee; 

        public LoggerDecorator(Logger logger)
        {
            wrappee = logger; 
        }

        public override void LogEvent(string message)
        {
            wrappee.LogEvent(message); 
        }
    }
}
