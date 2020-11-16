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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

            using (SqlConnection Con = new SqlConnection(CS))
            {
                /*
                SqlCommand Com = new SqlCommand("Select ID,Name,Description From TBLProducts", Con);
                Con.Open();
                GridView1.DataSource = Com.ExecuteReader();
                GridView1.DataBind();
                */

                /*
                SqlCommand Com = new SqlCommand("Insert into TBLProducts values (5,'Sony','PSP')", Con);
                Con.Open();
                int TotalRowsAffected = Com.ExecuteNonQuery();
                Response.Write("Total Rows Insart " + TotalRowsAffected.ToString());
                */

                /*
                SqlCommand Com = new SqlCommand("Update TBLProducts set Name = 'Windows' where ID = 5 ", Con);
                Con.Open();
                int TotalRowsAffected = Com.ExecuteNonQuery();
                Response.Write("Total Rows Update " + TotalRowsAffected.ToString());
                */

                /*
                SqlCommand Com = new SqlCommand("Delete From TBLProducts where ID = 5", Con);
                Con.Open();
                int TotalRowsAffected = Com.ExecuteNonQuery();
                Response.Write("Total Rows Delete " + TotalRowsAffected.ToString());
                */

                /*
                SqlCommand Com = new SqlCommand("Select count (ID) from TBLProducts", Con);
                Con.Open();
                int TotalRowsAffected = (int)Com.ExecuteScalar();
                Response.Write("Total Rows Select count " + TotalRowsAffected.ToString());
                */
            }
        }
    }
}