using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Page01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Database connection strings
        string connectionString = "Data Source=(local);Initial Catalog=MyDB;Integrated Security=True;";

        string query = "SELECT R.[Id] AS [ResultId], R.[StudentId], R.[Year], R.[Cgpa], S.[Name] AS [StudentName], " +
            "RS.[SubjectId], RS.[Level], RS.[Mark] AS [ResultSubjectMark], RS.[Weightage] AS [ResultSubjectWeightage], " +
            "Sub.[Title] AS [SubjectTitle], MD.[Type] AS [MetricDataType], MD.[Mark] AS [MetricDataMark], " +
            "MD.[Weightage] AS [MetricDataWeightage], A.[Type] AS [AssessmentType], A.[Mark] AS [AssessmentMark], " +
            "A.[Weightage] AS [AssessmentWeightage] FROM [Result] R " +
            "LEFT JOIN [Student] S ON R.[StudentId] = S.[Id] " +
            "LEFT JOIN [ResultSubject] RS ON R.[Id] = RS.[ResultId] " +
            "LEFT JOIN [Subject] Sub ON RS.[SubjectId] = Sub.[Id] " +
            "LEFT JOIN [MetricData] MD ON R.[Id] = MD.[ResultId] " +
            "LEFT JOIN [Assessment] A ON R.[Id] = A.[ResultId];";

        SqlConnection conn = new SqlConnection(connectionString);
        conn.Open();
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "TblResult");

            gvResult.DataSource = ds;
            gvResult.DataMember = "TblResult";
            gvResult.DataBind();    
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