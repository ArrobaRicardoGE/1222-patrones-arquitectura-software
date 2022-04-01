using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniApp
{
    /// <summary>
    /// Director that coordinates the creation of Forms. 
    /// </summary>
    class FormDirector
    {
        public void Construct(FormBuilder builder)
        {
            builder.SetTitle();
            builder.BuildInfo();
            builder.BuildGrades();
            builder.BuildDownloadGrades();
        }
    }
}
