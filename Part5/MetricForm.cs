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
    public partial class MetricForm : Form
    {
        public MetricForm()
        {
            InitializeComponent();
        }

        private void MetricFormcs_Load(object sender, EventArgs e)
        {
            // Populate the ComboBox with enum values
            comboBox1.DataSource = Enum.GetValues(typeof(Metrics));
        }

        private void clearForm()
        {
            tbMark.Text = string.Empty;
            tbMetric.Text = string.Empty;
            comboBox1.SelectedIndex = 0;
            tbMetric.Text = comboBox1.SelectedItem.ToString();
        }

        private void btnAddMetric_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(local);Initial Catalog=MyDB;Integrated Security=True;";
            string insertMetricDataQuery = "INSERT INTO [MetricData] (Type,Mark, Weightage, ResultId) VALUES (@Type, @Mark, @Weightage, @ResultId)";
            string getResultIdQuery = "SELECT * FROM [Result] WHERE StudentId = @StudentId AND Year = @Year";

            string studentId = tbStudentId.Text;
            int year = int.Parse(tbYear.Text);
            string metric = tbMetric.Text;
            float metricWeight = float.Parse(tbWeightage.Text);
            float metricMark = float.Parse(tbMark.Text);
            int resultId = 0;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();


            try
            {
                SqlCommand commandResult = new SqlCommand(getResultIdQuery, conn);
                commandResult.Parameters.AddWithValue("@StudentId", studentId);
                commandResult.Parameters.AddWithValue("@Year", Year);

                using (SqlDataReader reader = commandResult.ExecuteReader())
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

                SqlCommand cmd = new SqlCommand(insertMetricDataQuery, conn);
                cmd.Parameters.AddWithValue("@Type", metric);
                cmd.Parameters.AddWithValue("@Mark", metricMark);
                cmd.Parameters.AddWithValue("@Weightage", metricWeight);
                cmd.Parameters.AddWithValue("@ResultId", resultId);

                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("Operation successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to insert a new record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                clearForm();

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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Metrics selectedMetric = (Metrics)comboBox1.SelectedItem;
            tbMetric.Text = selectedMetric.ToString();
        }
    }

}

