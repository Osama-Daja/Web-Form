using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ASP.net_ADO.net_Demo
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

            using(SqlConnection Con = new SqlConnection(CS))
            {
                SqlDataAdapter DA = new SqlDataAdapter("GETData", Con);
                DA.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                DA.SelectCommand.Parameters.AddWithValue("@ProductId", TextBox1.Text);

                DataSet DS = new DataSet();
                DA.Fill(DS);
                GridView1.DataSource = DS;
                GridView1.DataBind();
            }
        }
    }
}