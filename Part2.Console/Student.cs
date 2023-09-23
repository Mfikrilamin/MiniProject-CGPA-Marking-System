using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    public class Student
    {
        readonly string _Id;
        readonly string _Name;
        public string Id
        {
            get => _Id;
        }

        public string Name
        {
            get => _Name;
        }

        CGPA CGPA { get; set; }

        public Student(string id, string name)
        {
            _Id = id;
            _Name = name;
        }
    }
}
