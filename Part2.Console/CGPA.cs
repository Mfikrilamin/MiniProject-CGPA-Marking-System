using FoundationClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    public class CGPA : MeasurementUnit
    {
        public CGPA(string id, params Node[] nodes) : base(id, nodes)
        {
        }
    }
}
