using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniApp
{
    class JSONDataSourceAdapter : Database
    {
        private JSONDataSource ds; 
        public JSONDataSourceAdapter()
        {
            ds = JSONDataSource.Instance; 
        }
        public override User GetUserByUsername(string username)
        {
            foreach (var x in ds.Users.Data)
                if (x.Username == username) return x;
            throw new Exception($"User {username} not found"); 
        }

        public override Info GetInfoByUserID(int user_id)
        {
            foreach(var x in ds.Info.Data)
                if (x.UserID == user_id) return x;
            throw new Exception($"Information for user {user_id} not found");
        }

        public override List<Grade> GetGradesByStudentID(int student_id)
        {
            List<Grade> res = new(); 
            foreach(var x in ds.Grades.Data)
                if (x.StudentID == student_id) res.Add(x);

            res.Sort(delegate (Grade g1, Grade g2)
            {
                if (g1.Subject == g2.Subject) return 0;
                else return g1.Subject.CompareTo(g2.Subject);
            });

            return res; 
        }

        public override List<Grade> GetGradesByTeacherID(int teacher_id)
        {
            List<Grade> res = new();
            foreach (var x in ds.Grades.Data)
                if (x.TeacherID == teacher_id) res.Add(x);

            res.Sort(delegate (Grade g1, Grade g2)
            {
                if (g1.Subject == g2.Subject) return g1.StudentID.CompareTo(g2.StudentID);
                else return g1.Subject.CompareTo(g2.Subject);
            });

            return res;
        }

    }
}
