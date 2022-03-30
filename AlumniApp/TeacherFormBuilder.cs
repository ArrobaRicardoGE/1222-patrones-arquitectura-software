using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniApp
{
    class TeacherFormBuilder : FormBuilder
    {
        public TeacherFormBuilder(User user) : base(user) { }

        public override void SetTitle()
        {
            _form.Text = "AlumniApp: Teacher";
        }

        public override void BuildGrades()
        {
            throw new NotImplementedException();
        }

        public override void BuildInfo()
        {
            throw new NotImplementedException();
        }

        public override void BuildDownloadGrades()
        {
            throw new NotImplementedException();
        }
    }
}
