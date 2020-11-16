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
    public partial class WebForm4 : System.Web.UI.Page
    {
        int ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                Con.Open();
                SqlCommand COM = new SqlCommand("Select * From TBLProducts", Con);

                GridView1.DataSource = COM.ExecuteReader();
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                Con.Open();
                SqlCommand Com = new SqlCommand("Select * From TBLProducts Where Name like @Parametar", Con);
                Com.Parameters.AddWithValue("@Parametar", TextBox1.Text + "%");
                GridView1.DataSource = Com.ExecuteReader();
                GridView1.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                Con.Open();
                SqlCommand ComID = new SqlCommand("Select count (ID) from TBLProducts", Con);
                ID = (int)ComID.ExecuteScalar();
                ID++;

                SqlCommand Com = new SqlCommand("Insert Into TBLProducts Values ("+ ID.ToString() + ",'" + TextBox3.Text + "','" + TextBox4.Text + "')" , Con);
                GridView1.DataSource = Com.ExecuteReader();
                GridView1.DataBind();
            }

            using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                Con.Open();
                SqlCommand Com = new SqlCommand("Select * from TBLProducts", Con);
                GridView1.DataSource = Com.ExecuteReader();
                GridView1.DataBind();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                SqlCommand Com = new SqlCommand("Delete From TBLProducts where ID =" + TextBox2.Text, Con);
                Con.Open();
                GridView1.DataSource = Com.ExecuteReader();
                GridView1.DataBind();
            }

            using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                Con.Open();
                SqlCommand Com = new SqlCommand("Select * from TBLProducts", Con);
                GridView1.DataSource = Com.ExecuteReader();
                GridView1.DataBind();
            }
        }
    }
}