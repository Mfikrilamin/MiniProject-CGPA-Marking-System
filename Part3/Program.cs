using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Part2;
using FoundationClass;

namespace Part3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Database connection strings
            string connectionString = "Data Source=(local);Initial Catalog=MyDB;Integrated Security=True;";

            // SQL query with parameters
            string insertStudentQuery = "INSERT INTO [Student] (Id, Name) VALUES (@Id, @Name)";
            string insertSubjectQuery = "INSERT INTO [Subject] (Id, Title) VALUES (@Id, @Title)";
            string insertAssessmentQuery = "INSERT INTO [Assessment] (Type, Mark, Weightage, SubjectId, ResultId) VALUES (@Type, @Mark, @Weightage, @SubjectId, @ResultId)";
            string insertResultSubjectQuery = "INSERT INTO [ResultSubject] (ResultId, SubjectId, Level, Mark, Weightage) VALUES (@ResultId, @SubjectId, @Level, @Mark, @Weightage)";
            string insertMetricDataQuery = "INSERT INTO [MetricData] (Type,Mark, Weightage, SubjectId, ResultId) VALUES (@Type, @Mark, @Weightage, @SubjectId, @ResultId)";

            string studentQuery = "SELECT * FROM [Student]";

            //Auto generated ID
            string insertResultQuery = "INSERT INTO Result (Id, StudentId, Year, Cgpa) VALUES (@Id, @StudentId, @Year, @Cgpa,)";

            //Main CRUD Operation
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            try
            {
                Student student1 = new Student("AC19EC0096", "Muhammad Fikri Bin Abdullamin");

                Subject TMX2013 = new Subject(id: "TMX2013", title: "Transaction Mathematic",
                    new Assessement(assessment: Assessments.Test.ToString(), weightage: 0.1f, value: new ValueNode(60.0f)),
                    new Assessement(assessment: Assessments.Quiz.ToString(), weightage: 0.3f, value: new ValueNode(70.0f)),
                    new Assessement(assessment: Assessments.CaseStudy.ToString(), weightage: 0.2f, value: new ValueNode(80.0f)),
                    new Assessement(assessment: Assessments.Assingment.ToString(), weightage: 0.3f, value: new ValueNode(90.0f))
                );

                Subject TMX2014 = new Subject(id: "TMX2014", title: "Business",
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

                Subject TMT2035 = new Subject(id: "TMT2035", title: "Information Technology",
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



                SqlCommand cmd = new SqlCommand(studentQuery, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"StudentId: {dr["Id"]} ,Student Name: {dr["Name"]}");
                }
                dr.Close();

                // Add parameters
                //cmd.Parameters.AddWithValue("@FirstName", "AnyVariable");
                //cmd.Parameters.AddWithValue("@LastName", "AnyVariable");
                //cmd.Parameters.AddWithValue("@Age", "AnyVariable");

                // Execute the insert command
                //int rowsAffected = cmd.ExecuteNonQuery();

                //Console.WriteLine($"Rows affected: {rowsAffected}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Invalid argument value " + ex.Message);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Code:{0}\nMessage:{1}", ex.Number, ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }


        }
    }
}
