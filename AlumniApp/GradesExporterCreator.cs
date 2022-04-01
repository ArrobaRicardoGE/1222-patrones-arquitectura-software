using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AlumniApp
{
    class GradesExporterCreator
    {
        public static GradesExporter FactoryMethod()
        {
            var type = ConfigurationManager.AppSettings["format"];
            if (type == "txt") return new TXTGradesExporter();
            if (type == "docx") return new DOCXGradesExporter();
            return null; 
        }
    }
}
