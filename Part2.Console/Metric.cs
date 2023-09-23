using FoundationClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{

    public enum Metrics
    {
        GPA,
        Cocuriculum,
        Internship,
        Attitude
    }
    public class Metric : Node
    {
        Metrics metric
        {
            get;
        }
        public Metric(Metrics metric, float weightage, IValueable value) : base(weightage, value)
        {
            this.metric = metric;
        }
    }
}
