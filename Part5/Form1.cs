using FoundationClass;
using Part2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Part5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            Subject subject = new Subject();
            subject.Show();
        }

        private void clearForm()
        {
            tbStudentId.Text = string.Empty;
            tbStudentName.Text = string.Empty;
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            string studentId = tbStudentId.Text;
            string studentName = tbStudentName.Text;
            //add to database
            string connectionString = "Data Source=(local);Initial Catalog=MyDB;Integrated Security=True;";

            // SQL query with parameters
            string insertStudentQuery = "INSERT INTO [Student] (Id, Name) VALUES (@Id, @Name)";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(insertStudentQuery, conn);
            try
            {
                cmd.Parameters.AddWithValue("@Id", studentId);
                cmd.Parameters.AddWithValue("@Name", studentName);
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("Operation successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearForm();
                }
                else
                {
                    MessageBox.Show("Failed to insert a new record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

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
                cmd.Dispose();
                if ((conn != null) && (conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }
        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            Subject subject = new Subject();
            subject.Show();
        }

        private void btnCalculateCGPA_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(local);Initial Catalog=MyDB;Integrated Security=True;";
            string studentId = tbStudentId.Text;
            string year = tbYear.Text;
            int resultId = 0;
            // SQL query with parameters
            string getResultIdQuery = "SELECT * FROM [Result] WHERE StudentId = @StudentId AND Year = @Year";
            string updateResult = "UPDATE [Result] SET Cgpa = @CGPA WHERE Id = @ResultId AND StudentId = @StudentId";
            string metricDataQuery = "SELECT * FROM [MetricData] WHERE ResultId = @Resultid";

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
                        MessageBox.Show("Failed to read record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }


                //CalculateCGPA
                SqlCommand cmd1 = new SqlCommand(metricDataQuery, conn);
                cmd1.Parameters.AddWithValue("@ResultId", resultId);
                SqlDataReader dr = cmd1.ExecuteReader();

                List<Metric> metricData = new List<Metric>();
                Metrics metric;
                while (dr.Read())
                {
                    if (dr["Type"].ToString() == Metrics.Cocuriculum.ToString())
                    {
                        metric = Metrics.Cocuriculum;
                    }
                    else if (dr["Type"].ToString() == Metrics.Attitude.ToString())
                    {
                        metric = Metrics.Attitude;
                    }
                    else if (dr["Type"].ToString() == Metrics.Internship.ToString())
                    {
                        metric = Metrics.Internship;
                    }
                    else
                    {
                        metric = Metrics.GPA;
                    }

                    metricData.Add(new Metric(
                        metric, 
                        (float)dr.GetDecimal(dr.GetOrdinal("Weightage")), 
                        new ValueNode((float)dr.GetDecimal(dr.GetOrdinal("Mark")))));
                }
                dr.Close();

       

                CGPA cgpa = new CGPA(resultId.ToString(), metricData.ToArray());


                //Update result in database
                SqlCommand cmd3 = new SqlCommand(updateResult, conn);
                cmd3.Parameters.AddWithValue("@ResultId", resultId);
                cmd3.Parameters.AddWithValue("@StudentId", studentId);
                cmd3.Parameters.AddWithValue("@CGPA", cgpa.Value * 0.0F);

                int n = cmd3.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("Sucessfull calculate CGPA", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearForm();
                }
                else
                {
                    MessageBox.Show("Failed to update CGPA value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                lblCGPA.Text = (cgpa.Value * 0.04F).ToString();

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

        private void btnAddMetric_Click(object sender, EventArgs e)
        {
            MetricForm metric = new MetricForm();
            metric.Show();

        }
    }
}
