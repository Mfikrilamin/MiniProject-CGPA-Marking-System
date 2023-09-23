using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using Part2;
using FoundationClass;

namespace Part4.UnitTesting
{
    [TestClass]
    public class SubjectMark
    {
        [TestMethod]
        public void SubjectMark_Test01()
        {
            //Arrange
            float expected = 62.40f;

            Subject TMX2014 = new Subject(id: "TMX2014", title: "Transaction Mathematic",
              new Assessement(assessment: Assessments.Test, weightage: 0.2f, value: new ValueNode(60.0f)),
              new Assessement(assessment: Assessments.Quiz, weightage: 0.1f, value: new ValueNode(58.0f)),
              new Assessement(assessment: Assessments.CaseStudy, weightage: 0.5f, value: new ValueNode(78.0f)),
              new Assessement(assessment: Assessments.Assingment, weightage: 0.2f, value: new ValueNode(28.0f))
              );
           
            //Act
            float actual = TMX2014.Value;
            actual = (float)Math.Round(actual, 2);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubjectMark_Test02()
        {
            //Arrange
            float expected = 0.0f;

            Subject TMX2014 = new Subject(id: "TMX2014", title: "Transaction Mathematic",
              new Assessement(assessment: Assessments.Test, weightage: 0.2f, value: new ValueNode(0.00f)),
              new Assessement(assessment: Assessments.Quiz, weightage: 0.1f, value: new ValueNode(0.00f)),
              new Assessement(assessment: Assessments.CaseStudy, weightage: 0.5f, value: new ValueNode(0.00f)),
              new Assessement(assessment: Assessments.Assingment, weightage: 0.2f, value: new ValueNode(0.00f))
              );
       
            //Act
            float actual = TMX2014.Value;
            actual = (float)Math.Round(actual, 2);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SubjectMark_Test03()
        {
            //Arrange
            float expected = 100.0f;

            Subject TMX2014 = new Subject(id: "TMX2014", title: "Transaction Mathematic",
              new Assessement(assessment: Assessments.Test, weightage: 0.2f, value: new ValueNode(100.00f)),
              new Assessement(assessment: Assessments.Quiz, weightage: 0.1f, value: new ValueNode(100.00f)),
              new Assessement(assessment: Assessments.CaseStudy, weightage: 0.5f, value: new ValueNode(100.00f)),
              new Assessement(assessment: Assessments.Assingment, weightage: 0.2f, value: new ValueNode(100.00f))
              );
         
            //Act
            float actual = TMX2014.Value;
            actual = (float)Math.Round(actual, 2);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SubjectMark_Test04()
        {
            //Arrange
            float expected = 54.75f;

            Subject TMX2014 = new Subject(id: "TMX2014", title: "Transaction Mathematic",
              new Assessement(assessment: Assessments.Test, weightage: 0.1f, value: new ValueNode(20.00f)),
              new Assessement(assessment: Assessments.Quiz, weightage: 0.1f, value: new ValueNode(50.00f)),
              new Assessement(assessment: Assessments.CaseStudy, weightage: 0.4f, value: new ValueNode(78.00f)),
              new Assessement(assessment: Assessments.Assingment, weightage: 0.2f, value: new ValueNode(28.00f))
              );
           
            //Act
            float actual = TMX2014.Value;
            actual = (float)Math.Round(actual, 2);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubjectMark_Test05()
        {
            //Arrange and act
            Action createSubject = () => new Subject(id: "TMX2014", title: "Transaction Mathematic",
              new Assessement(assessment: Assessments.Test, weightage: -0.2f, value: new ValueNode(60.00f)),
              new Assessement(assessment: Assessments.Quiz, weightage: -0.1f, value: new ValueNode(58.00f)),
              new Assessement(assessment: Assessments.CaseStudy, weightage: 0.5f, value: new ValueNode(78.00f)),
              new Assessement(assessment: Assessments.Assingment, weightage: 0.2f, value: new ValueNode(28.00f))
              );

            //Assert
            Assert.ThrowsException<ArgumentException>(createSubject);
        }

        [TestMethod]
        public void SubjectMark_Test06()
        {
            //Arrange and act
            Action createSubject = () => new Subject(id: "TMX2014", title: "Transaction Mathematic",
              new Assessement(assessment: Assessments.Test, weightage: 0.2f, value: new ValueNode(160.00f)),
              new Assessement(assessment: Assessments.Quiz, weightage: 0.1f, value: new ValueNode(558.00f)),
              new Assessement(assessment: Assessments.CaseStudy, weightage: 0.5f, value: new ValueNode(78.00f)),
              new Assessement(assessment: Assessments.Assingment, weightage: 0.2f, value: new ValueNode(28.00f))
              );

            //Assert
            Assert.ThrowsException<ArgumentException>(createSubject);
        }
    }
}
