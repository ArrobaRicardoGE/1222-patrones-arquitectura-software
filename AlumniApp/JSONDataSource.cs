using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace AlumniApp
{
    /// <summary>
    /// Encapsulates all the logic to get the information from the JSON files.
    /// It is a Singleton to avoid reading the same file multiple times. It will 
    /// also be useful in the future if updating data is enabled, to avoid writing 
    /// to the file from several sources at the same time. 
    /// </summary>
    class JSONDataSource
    {
        private static JSONDataSource _instance = null;
        private static object _handle = new();
        public JSONUserList Users { get; set; }
        public JSONInfoList Info { get; set; }
        public JSONGradeList Grades { get; set; }
        protected JSONDataSource() {
            // Files must be placed in the root directory of the application
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

    // Below are the classes used to parse our JSON into C# objects. 

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
