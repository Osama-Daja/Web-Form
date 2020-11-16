using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace ASP.net_ADO.net_Demo
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

            if (Cache["DATA"] == null)
            {
                using (SqlConnection Con = new SqlConnection(CS))
                {
                    SqlDataAdapter DA = new SqlDataAdapter("select * From TBLEmployees", Con);

                    DataSet DS = new DataSet();
                    DA.Fill(DS);
                    Cache["DATA"] = DS;
                    GridView1.DataSource = DS;
                    GridView1.DataBind();
                    Label1.Text = "Data Loaded From DataBase";
                }
            }else
            {
                Label1.Text = "Data Loaded From Cache";
                GridView1.DataSource = (DataSet)Cache["DATA"];
                GridView1.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Cache["DATA"] != null)
            {
                Cache.Remove("DATA");
                Label1.Text = "Data Set Removed From the Cache";
            }
            else
            {
                Label1.Text = "Ther is Notheng In the Cache Data";
            }
        }
    }
}