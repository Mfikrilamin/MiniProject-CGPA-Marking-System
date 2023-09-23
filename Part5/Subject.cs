using FoundationClass;
using Part2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.Reflection.Emit;

namespace Part5
{
    public partial class Subject : Form
    {
        public Subject()
        {
            InitializeComponent();
        }
        private void ClearForm()
        {
            tbStudentId.Text = "";
            tbSubjectId.Text = ""; // Clear text in TextBox
            tbSubjectTitle.Text = "";
            tbAssignmentWeight.Text = "";
            tbAssingmentMark.Text = "";
            tbCaseStudyWeight.Text = "";
            tbCaseStudyMark.Text = "";
            tbQuizWeight.Text = "";
            tbQuizMark.Text = "";
            tbTestMark.Text = "";
            tbTestWeight.Text = "";
            comboBox1.SelectedIndex = 0; // Clear selected item in ComboBox
            tbSubjectLevel.Text = comboBox1.SelectedItem.ToString(); // Deselect radio buttons
        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            string studentId = tbStudentId.Text;
            int year = int.Parse(tbYear.Text);
            string subjectId = tbSubjectId.Text;
            string subjectTitle = tbSubjectTitle.Text;
            float subjectWeight = float.Parse(tbSubjectWeightage.Text);
            string subjectLevel = tbSubjectLevel.Text;
            float assignmentWeight = float.Parse(tbAssignmentWeight.Text);
            float assingmentMark = float.Parse(tbAssingmentMark.Text);
            float caseStudyWeight = float.Parse(tbCaseStudyWeight.Text);
            float caseStudyMark = float.Parse(tbCaseStudyMark.Text);
            float quizWeight = float.Parse(tbQuizWeight.Text);
            float quizMark = float.Parse(tbQuizMark.Text);
            float testWeight = float.Parse(tbTestWeight.Text);
            float testMark = float.Parse(tbTestMark.Text);
            int resultId = 0;

            Assessement[] listAssessment = new Assessement[]
            {
                new Assessement(Assessments.Assingment.ToString(), assignmentWeight, new ValueNode(assingmentMark)),
                new Assessement(Assessments.CaseStudy.ToString(), caseStudyWeight, new ValueNode(caseStudyMark)),
                new Assessement(Assessments.Quiz.ToString(), quizWeight, new ValueNode(quizMark)),
                new Assessement(Assessments.Test.ToString(), testWeight, new ValueNode(testMark))
            };

            Part2.Subject newSubject = new Part2.Subject(subjectId, subjectTitle,listAssessment);

            //add to database
            string connectionString = "Data Source=(local);Initial Catalog=MyDB;Integrated Security=True;";

            // SQL query with parameters
            string insertSubjectQuery = "INSERT INTO [Subject] (Id, Title) VALUES (@Id, @Title)";
            string insertAssessmentQuery = "INSERT INTO [Assessment] (Type, Mark, Weightage, SubjectId, ResultId) VALUES (@Type, @Mark, @Weightage, @SubjectId, @ResultId)";
            string insertResultSubjectQuery = "INSERT INTO [ResultSubject] (ResultId, SubjectId, Level, Mark, Weightage) VALUES (@ResultId, @SubjectId, @Level, @Mark, @Weightage)";
            string getResultIdQuery = "SELECT Id FROM [Result] WHERE StudentId = @StudentId AND Year = @Year";
            string insertResultQuery = "INSERT INTO Result (StudentId, Year) VALUES (@StudentId, @Year)";
            string insertMetricDataQuery = "INSERT INTO [MetricData] (Type,Mark, Weightage, ResultId) VALUES (@Type, @Mark, @Weightage, @ResultId)";
            string queryResultSubject = "SELECT * FROM [ResultSubject] WHERE ResultId = @ResultId";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            try
            {

                SqlCommand cmd = new SqlCommand(getResultIdQuery, conn);
                cmd.Parameters.AddWithValue("@StudentId", studentId);
                cmd.Parameters.AddWithValue("@Year", year);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int idColumnIndex = reader.GetOrdinal("Id"); // Get the index of the "Id" column by name
                        resultId = reader.GetInt32(idColumnIndex);
                    }
                    else
                    {
                        reader.Close();
                        SqlCommand command = new SqlCommand(insertResultQuery, conn);
                        command.Parameters.AddWithValue("@StudentId", studentId);
                        command.Parameters.AddWithValue("@Year", year);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Retrieve the last inserted ID
                            string getLastIdQuery = "SELECT IDENT_CURRENT('Result')";
                            using (SqlCommand getIdCommand = new SqlCommand(getLastIdQuery, conn))
                            {
                                object result = getIdCommand.ExecuteScalar();
                                if (result != null)
                                {
                                    resultId = Convert.ToInt32(result);
                                }
                                else
                                {
                                    // Handle the case where the ID retrieval failed
                                    MessageBox.Show("Record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            // Handle the case where the INSERT failed
                            MessageBox.Show("Failed to insert a new record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                SqlCommand cmd1 = new SqlCommand(insertSubjectQuery, conn);

                SqlCommand cmd2 = new SqlCommand(insertAssessmentQuery, conn);
                SqlCommand cmd3 = new SqlCommand(insertResultSubjectQuery, conn);
                SqlCommand cmd4 = new SqlCommand(queryResultSubject, conn);
                SqlCommand cmd5 = new SqlCommand(insertMetricDataQuery, conn);
                int j = 0;
                // Add parameters
                cmd1.Parameters.AddWithValue("@Id", subjectId);
                cmd1.Parameters.AddWithValue("@Title", subjectTitle);
                int i = cmd1.ExecuteNonQuery();

                cmd2.Parameters.AddWithValue("@Type", Assessments.Quiz.ToString());
                cmd2.Parameters.AddWithValue("@Mark", quizMark);
                cmd2.Parameters.AddWithValue("@Weightage", quizWeight);
                cmd2.Parameters.AddWithValue("@SubjectId", subjectId);
                cmd2.Parameters.AddWithValue("@ResultId", resultId);
                j += cmd2.ExecuteNonQuery();
                cmd2.Parameters.Clear();

                cmd2.Parameters.AddWithValue("@Type", Assessments.Test.ToString());
                cmd2.Parameters.AddWithValue("@Mark", testMark);
                cmd2.Parameters.AddWithValue("@Weightage", testWeight);
                cmd2.Parameters.AddWithValue("@SubjectId", subjectId);
                cmd2.Parameters.AddWithValue("@ResultId", resultId);
                j += cmd2.ExecuteNonQuery();
                cmd2.Parameters.Clear();

                cmd2.Parameters.AddWithValue("@Type", Assessments.Assingment.ToString());
                cmd2.Parameters.AddWithValue("@Mark", assingmentMark);
                cmd2.Parameters.AddWithValue("@Weightage", assignmentWeight);
                cmd2.Parameters.AddWithValue("@SubjectId", subjectId);
                cmd2.Parameters.AddWithValue("@ResultId", resultId);
                j += cmd2.ExecuteNonQuery();
                cmd2.Parameters.Clear();

                cmd2.Parameters.AddWithValue("@Type", Assessments.CaseStudy.ToString());
                cmd2.Parameters.AddWithValue("@Mark", caseStudyMark);
                cmd2.Parameters.AddWithValue("@Weightage", caseStudyWeight);
                cmd2.Parameters.AddWithValue("@SubjectId", subjectId);
                cmd2.Parameters.AddWithValue("@ResultId", resultId);
                j += cmd2.ExecuteNonQuery();

                cmd3.Parameters.AddWithValue("@ResultId", resultId);
                cmd3.Parameters.AddWithValue("@SubjectId", subjectId);
                cmd3.Parameters.AddWithValue("@Level", subjectLevel);
                cmd3.Parameters.AddWithValue("@Mark", newSubject.Value);
                cmd3.Parameters.AddWithValue("@Weightage", subjectWeight);

          
                int k = cmd3.ExecuteNonQuery();

                if (i > 0 && j > 0 && k > 0)
                {
                    MessageBox.Show("Operation successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Operation failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                

                //Calculate GPA based on added subject


                //Insert GPA Into Metric
                cmd4.Parameters.AddWithValue("@Type", Metrics.GPA.ToString());
                cmd4.Parameters.AddWithValue("@Mark", subjectId);
                cmd4.Parameters.AddWithValue("@Weightage", 0.05);
                cmd4.Parameters.AddWithValue("@ResultId",resultId);
                ClearForm();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Something wrong with database \n Code:{ex.Number}\nMessage:{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something wrong system \n Message:{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        private void Subject_Load(object sender, EventArgs e)
        {
            // Populate the ComboBox with enum values
            comboBox1.DataSource = Enum.GetValues(typeof(Levels));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Levels selectedLevel = (Levels)comboBox1.SelectedItem;
            tbSubjectLevel.Text = selectedLevel.ToString();
        }
    }
}
