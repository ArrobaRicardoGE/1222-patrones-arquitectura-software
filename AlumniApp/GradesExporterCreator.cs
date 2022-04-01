using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AlumniApp
{
    /// <summary>
    /// Main class of the grades exporter factory. For simplicity, its only method is static
    /// </summary>
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
