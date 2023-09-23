using FoundationClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{

    //Reason being is to pinpoint which assessment that affect mark of student 
    /// <summary>
    /// Type of the assessment. Can be add/remove in the future depending on the requirement.
    /// <para></para>
    /// Help to pinpoint problem in any assessment that affect student's subject mark
    /// </summary>
    public enum Assessments
    {
        Assingment,
        CaseStudy,
        Test,
        Quiz,
        Lab,
        Exam
    }

    public class Assessement : Node
    {
        string Assessment;
        public Assessement(string assessment, 
            float weightage, IValueable value) : base(weightage, value)
        {
            Assessment = assessment;
        }
    }


}
