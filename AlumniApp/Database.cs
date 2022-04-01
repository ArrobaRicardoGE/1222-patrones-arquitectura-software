using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniApp
{
    /// <summary>
    /// Defines the interface for the database adapters. Must be used when introducing a new 
    /// data source to reduce the code changes. If there are multiple interchangeable data 
    /// sources, it could be useful to implement a factory to further simplify the usage. 
    /// </summary>
    abstract class Database
    {
        /// <summary>
        /// Used in login, returns the user for the given username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>An instance of User with the corresponding one</returns>
        public abstract User GetUserByUsername(string username);
        /// <summary>
        /// Returns the info for the given user id
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns>An instance of Info with thce corresponding user information</returns>
        public abstract Info GetInfoByUserID(int user_id);
        /// <summary>
        /// Returns the grades for a given student id
        /// </summary>
        /// <param name="student_id"></param>
        /// <returns>A list of Grade for the given student</returns>
        public abstract List<Grade> GetGradesByStudentID(int student_id);
        /// <summary>
        /// Returns the grades for a given student id
        /// </summary>
        /// <param name="teacher_id"></param>
        /// <returns>A list of Grade for the given teacher</returns>
        public abstract List<Grade> GetGradesByTeacherID(int teacher_id); 
        
    }

    // Below are the classes used to represent our entities.
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
