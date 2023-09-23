using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using Part2;
using FoundationClass;

namespace Part4.UnitTesting
{
    [TestClass]
    public class GPAMark
    {
        [TestMethod]
        public void GPAMark_01()
        {
            //Arrange
            float expected = 77.00f;

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

            //Act
            float actual = GPA2020.Value;
            actual = (float)Math.Round(actual, 2);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
