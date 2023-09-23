using FoundationClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Part2;
using System;

namespace Part4.UnitTesting
{
    [TestClass]
    public class CGPAMark
    {
        [TestMethod]
        public void CGPAMark_01()
        {
            float expected = 3.20f;

            //Arrange
            Subject TMX2013 = new Subject(id: "TMX2013", title: "Transaction Mathematic",
             new Assessement(assessment: Assessments.Test, weightage: 0.1f, value: new ValueNode(60.0f)),
             new Assessement(assessment: Assessments.Quiz, weightage: 0.3f, value: new ValueNode(70.0f)),
             new Assessement(assessment: Assessments.CaseStudy, weightage: 0.2f, value: new ValueNode(80.0f)),
             new Assessement(assessment: Assessments.Assingment, weightage: 0.3f, value: new ValueNode(90.0f))
             );

            Subject TMX2014 = new Subject(id: "TMX2014", title: "Transaction Mathematic",
             new Assessement(assessment: Assessments.Test, weightage: 0.1f, value: new ValueNode(60.0f)),
             new Assessement(assessment: Assessments.Quiz, weightage: 0.3f, value: new ValueNode(70.0f)),
             new Assessement(assessment: Assessments.CaseStudy, weightage: 0.2f, value: new ValueNode(80.0f)),
             new Assessement(assessment: Assessments.Assingment, weightage: 0.3f, value: new ValueNode(90.0f))
             );

            Subject TMT2034 = new Subject(id: "TMT2034", title: "Economy",
              new Assessement(assessment: Assessments.Test, weightage: 0.2f, value: new ValueNode(80.0f)),
              new Assessement(assessment: Assessments.Quiz, weightage: 0.3f, value: new ValueNode(40.00f)),
              new Assessement(assessment: Assessments.CaseStudy, weightage: 0.3f, value: new ValueNode(90.00f)),
              new Assessement(assessment: Assessments.Assingment, weightage: 0.4f, value: new ValueNode(90.00f))
              );

            Subject TMT2035 = new Subject(id: "TMT2035", title: "Economy",
              new Assessement(assessment: Assessments.Test, weightage: 0.2f, value: new ValueNode(80.0f)),
              new Assessement(assessment: Assessments.Quiz, weightage: 0.3f, value: new ValueNode(40.00f)),
              new Assessement(assessment: Assessments.CaseStudy, weightage: 0.3f, value: new ValueNode(90.00f)),
              new Assessement(assessment: Assessments.Assingment, weightage: 0.4f, value: new ValueNode(90.00f))
              );

            GPA GPA2020 = new GPA(id: "2019",
                new Course(levels: Levels.Beginner, creditHour: 4.00f, value: TMX2014),
                new Course(levels: Levels.Itermediate, creditHour: 2.00f, value: TMX2014),
                new Course(levels: Levels.Itermediate, creditHour: 2.00f, value: TMT2034),
                new Course(levels: Levels.Itermediate, creditHour: 2.00f, value: TMT2035)
                );

            CGPA CGPA2020 = new CGPA(id: "2019",
                new Metric(metric: Metrics.GPA, weightage: 0.5F, value: GPA2020),
                new Metric(metric: Metrics.Cocuriculum, weightage: 0.2F, value: new ValueNode(80)),
                new Metric(metric: Metrics.Internship, weightage: 0.2F, value: new ValueNode(90)),
                new Metric(metric: Metrics.Attitude, weightage: 0.1F, value: new ValueNode(75))
                );

            //Act
            float actual = CGPA2020.Value * 0.04f;
            actual = (float) Math.Round(actual,2);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
