using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniApp
{
    /// <summary>
    /// Base abstraction for Form Builders. Each concrete builder must implement this interface.
    /// </summary>
    abstract class FormBuilder
    {
        protected BaseForm _form = new();
        protected User _user;
        protected Database _db; 

        public FormBuilder(User user)
        {
            _user = user;
            _db = new JSONDataSourceAdapter(); 
        }
        
        public BaseForm GetResult()
        {
            return _form;
        }

        public abstract void SetTitle(); 

        public abstract void BuildGrades();

        public abstract void BuildInfo();

        public abstract void BuildDownloadGrades(); 
    }
}
