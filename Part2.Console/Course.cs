using FoundationClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{

    public enum Levels
    {
        Beginner,
        Itermediate,
        Expert
    }
    public class Course : Node
    {
        public string Level
        {
            get;
        }
        public Course(string levels, float creditHour, IValueable value) : base(creditHour, value)
        {
            Level = levels;
        }
    }
}
