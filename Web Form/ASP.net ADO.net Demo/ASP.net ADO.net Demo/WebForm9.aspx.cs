using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ASP.net_ADO.net_Demo
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

            using(SqlConnection Con = new SqlConnection(CS))
            {
                SqlDataAdapter DA = new SqlDataAdapter("GetData", Con);
                DA.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet DS = new DataSet();
                DA.Fill(DS);

                DS.Tables[0].TableName = "TBLEmployees";
                GridView1.DataSource = DS.Tables["TBLEmployees"];
                GridView1.DataBind();

                DS.Tables[1].TableName = "TBLProducts";
                GridView2.DataSource = DS.Tables["TBLProducts"];
                GridView2.DataBind();

                /*
                GridView1.DataSource = DS.Tables[0];
                GridView1.DataBind();

                GridView2.DataSource = DS.Tables[1];
                GridView2.DataBind();
                */
            }
        }
    }
}