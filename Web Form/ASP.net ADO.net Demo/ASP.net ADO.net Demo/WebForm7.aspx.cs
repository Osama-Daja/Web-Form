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
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

            using(SqlConnection Con = new SqlConnection(CS))
            {
                SqlCommand Com = new SqlCommand("Select * from TBLProductsPriceRead; Select * from TBLProducts", Con);
                Con.Open();

                using(SqlDataReader RD = Com.ExecuteReader())
                {
                    GridView1.DataSource = RD;
                    GridView1.DataBind();

                    while (RD.NextResult())
                    {
                        GridView2.DataSource = RD;
                        GridView2.DataBind();
                    }
                }
            }
        }
    }
}