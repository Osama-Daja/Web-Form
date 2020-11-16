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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using(SqlConnection Con = new SqlConnection())
            {
            Con.ConnectionString = CS;

            SqlCommand Cmd = new SqlCommand();
            Cmd.CommandText = "Select * from TBLProducts";
            Cmd.Connection = Con;

            Con.Open();
            GridView1.DataSource = Cmd.ExecuteReader();
            GridView1.DataBind();
            }


        }
    }
}