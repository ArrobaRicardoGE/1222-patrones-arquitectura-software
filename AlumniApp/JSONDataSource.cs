using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace AlumniApp
{
    // Singleton
    class JSONDataSource
    {
        private static JSONDataSource _instance = null;
        private static object _handle = new();
        private JSONUserList Users;
        private JSONInfoList Info;
        private JSONGradeList Grades; 
        protected JSONDataSource() {
            Users = JsonSerializer.Deserialize<JSONUserList>(ReadJSON(@"..\..\..\users.json"));
            Info = JsonSerializer.Deserialize<JSONInfoList>(ReadJSON(@"..\..\..\users_information.json"));
            Grades = JsonSerializer.Deserialize<JSONGradeList>(ReadJSON(@"..\..\..\grades.json"));
        }

        public static JSONDataSource Instance
        {
            get
            {
                lock (_handle)
                {
                    if (_instance == null) _instance = new JSONDataSource(); 
                }

                return _instance; 
            }
        }
        
        private string ReadJSON(string filename)
        {
            using var stream = File.OpenRead(filename);
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        //public string GetUsers()
        //{
        //    return Users; 
        //}

        //public string GetInfo()
        //{
        //    using var reader = new StreamReader(s_info);
        //    var x = JsonSerializer.Deserialize<JSONInfoList>(reader.ReadToEnd());

        //    return x.Data[0].Name;
        //}

        //public string GetGrades()
        //{
        //    using var reader = new StreamReader(s_grades);
        //    var x = JsonSerializer.Deserialize<JSONGradeList>(reader.ReadToEnd());

        //    return x.Data[0].Grade + " " + x.Data[1].Grade;
        //}
    }

    class JSONUser
    {
        public string Username { get; set; }
        public int UserID { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
    }
    class JSONUserList
    {
        public List<JSONUser> Data { get; set; }
    }

    class JSONInfo
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Career { get; set; }
        public int BirthYear { get; set; }
        public string Hometown { get; set; }
    }

    class JSONInfoList
    {
        public List<JSONInfo> Data { get; set; }
    }

    class JSONGrade
    {
        public int StudentID { get; set; }
        public int TeacherID { get; set; }
        public string Subject { get; set; }
        public int Term { get; set; }
        public float Grade { get; set; }
    }

    class JSONGradeList
    {
        public List<JSONGrade> Data { get; set; }
    }
}
