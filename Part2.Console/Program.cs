using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoundationClass;

namespace Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Subject TMX2013 = new Subject(id: "TMX2013", title: "Transaction Mathematic",
                     new Assessement(assessment: Assessments.Test.ToString(), weightage: 0.1f, value: new ValueNode(60.0f)),
                     new Assessement(assessment: Assessments.Quiz.ToString(), weightage: 0.3f, value: new ValueNode(70.0f)),
                     new Assessement(assessment: Assessments.CaseStudy.ToString(), weightage: 0.2f, value: new ValueNode(80.0f)),
                     new Assessement(assessment: Assessments.Assingment.ToString(), weightage: 0.3f, value: new ValueNode(90.0f))
                     );

                Subject TMX2014 = new Subject(id: "TMX2014", title: "Transaction Mathematic",
                 new Assessement(assessment: Assessments.Test.ToString(), weightage: 0.1f, value: new ValueNode(60.0f)),
                 new Assessement(assessment: Assessments.Quiz.ToString(), weightage: 0.3f, value: new ValueNode(70.0f)),
                 new Assessement(assessment: Assessments.CaseStudy.ToString(), weightage: 0.2f, value: new ValueNode(80.0f)),
                 new Assessement(assessment: Assessments.Assingment.ToString(), weightage: 0.3f, value: new ValueNode(90.0f))
                 );

                Subject TMT2034 = new Subject(id: "TMT2034", title: "Economy",
                  new Assessement(assessment: Assessments.Test.ToString(), weightage: 0.2f, value: new ValueNode(80.0f)),
                  new Assessement(assessment: Assessments.Quiz.ToString(), weightage: 0.3f, value: new ValueNode(40.00f)),
                  new Assessement(assessment: Assessments.CaseStudy.ToString(), weightage: 0.3f, value: new ValueNode(90.00f)),
                  new Assessement(assessment: Assessments.Assingment.ToString(), weightage: 0.4f, value: new ValueNode(90.00f))
                  );

                Subject TMT2035 = new Subject(id: "TMT2035", title: "Economy",
                  new Assessement(assessment: Assessments.Test.ToString(), weightage: 0.2f, value: new ValueNode(80.0f)),
                  new Assessement(assessment: Assessments.Quiz.ToString(), weightage: 0.3f, value: new ValueNode(40.00f)),
                  new Assessement(assessment: Assessments.CaseStudy.ToString(), weightage: 0.3f, value: new ValueNode(90.00f)),
                  new Assessement(assessment: Assessments.Assingment.ToString(), weightage: 0.4f, value: new ValueNode(90.00f))
                  );

                GPA GPA2020 = new GPA(id: "2019",   
                    new Course(levels: Levels.Beginner.ToString(), creditHour: 4.00f, value: TMX2014),
                    new Course(levels: Levels.Itermediate.ToString(), creditHour: 2.00f, value: TMX2014),
                    new Course(levels: Levels.Itermediate.ToString(), creditHour: 2.00f, value: TMT2034),
                    new Course(levels: Levels.Itermediate.ToString(), creditHour: 2.00f, value: TMT2035)
                    );

                CGPA CGPA2020 = new CGPA(id: "2019",
                    new Metric(metric: Metrics.GPA, weightage: 0.5F, value: GPA2020),
                    new Metric(metric: Metrics.Cocuriculum, weightage: 0.2F, value: new ValueNode(80)),
                    new Metric(metric: Metrics.Internship, weightage: 0.2F, value: new ValueNode(90)),
                    new Metric(metric: Metrics.Attitude, weightage: 0.1F, value: new ValueNode(75))
                    );

                float CGPAResult = CGPA2020.Value * 0.04f;

                Console.WriteLine("CGPA Result {0:f2}", CGPAResult);
                Console.ReadKey();
            }
            catch (ArgumentException ex) 
            {
                Console.WriteLine ("Invalid argument value " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
