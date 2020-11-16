using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace ASP.net_ADO.net_Demo
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

            using(SqlConnection Con = new SqlConnection(CS))
            {
                SqlCommand Com = new SqlCommand("spAddEmployee", Con);
                Com.CommandType = System.Data.CommandType.StoredProcedure;

                Com.Parameters.AddWithValue("@Name", TextBox1.Text);
                Com.Parameters.AddWithValue("@Gender", DropDownList1.Text);
                Com.Parameters.AddWithValue("@Salary", TextBox2.Text);

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@EmployeeId";
                sqlParameter.SqlDbType = System.Data.SqlDbType.Int;
                sqlParameter.Direction = System.Data.ParameterDirection.Output;

                Com.Parameters.Add(sqlParameter);

                Con.Open();
                Com.ExecuteNonQuery();
                TextBox3.Text = "Employee ID = " + sqlParameter.Value.ToString();
            }
        }
    }
}