using FoundationClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    public class Subject : MeasurementUnit
    {
        string Title
        {
            get;
        }
        public Subject(string id, string title, params Node[] nodes) : base(id, nodes)
        {
            Title = title;
        }

        //Later override if need
        //public override float XNormalize
        //{
        //    get
        //    {
        //        return 0f;
        //    }
        //}
    }
}
