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
        public JSONUserList Users { get; set; }
        public JSONInfoList Info { get; set; }
        public JSONGradeList Grades { get; set; }
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
    }

    class JSONUserList
    {
        public List<User> Data { get; set; }
    }

    class JSONInfoList
    {
        public List<Info> Data { get; set; }

    }

    class JSONGradeList
    {
        public List<Grade> Data { get; set; }
    }
}
