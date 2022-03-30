using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniApp
{
    abstract class Database
    {
        public abstract User GetUserByUsername(string username);
        public abstract Info GetInfoByUserID(int user_id);
        public abstract List<Grade> GetGradesByStudentID(int student_id);
        public abstract List<Grade> GetGradesByTeacherID(int teacher_id); 
        
    }
    class User
    {
        public string Username { get; set; }
        public int UserID { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
    }

    class Info
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Career { get; set; }
        public int BirthYear { get; set; }
        public string Hometown { get; set; }
    }

    class Grade
    {
        public int StudentID { get; set; }
        public int TeacherID { get; set; }
        public string Subject { get; set; }
        public float Term1 { get; set; }
        public float Term2 { get; set; }
        public float Term3 { get; set; }
    }
}
