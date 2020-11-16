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
    public partial class WebForm13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string Cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

            if (!IsPostBack)
            {
                using (SqlConnection Con = new SqlConnection(Cs))
                {
                    string Query = "Select * From TBLStudents";
                    SqlDataAdapter DA = new SqlDataAdapter(Query, Con);

                    DataSet DS = new DataSet();
                    DA.Fill(DS, "Students");

                    Session["DATASET"] = DS;
                    GridView1.DataSource = from dataRow in DS.Tables["Students"].AsEnumerable()
                                           select new Student
                                           {
                                               ID = Convert.ToInt32(dataRow["ID"]),
                                               TotalMarks = Convert.ToInt32(dataRow["TotalMarks"]),
                                               Name = dataRow["Name"].ToString(),
                                               Gender = dataRow["Gender"].ToString()
                                           };
                    GridView1.DataBind();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet DS = (DataSet)Session["DATASET"];

            if(string.IsNullOrEmpty(TextBox1.Text))
            {
                GridView1.DataSource = from dataRow in DS.Tables["Students"].AsEnumerable()
                                       select new Student
                                       {
                                           ID = Convert.ToInt32(dataRow["ID"]),
                                           TotalMarks = Convert.ToInt32(dataRow["TotalMarks"]),
                                           Name = dataRow["Name"].ToString(),
                                           Gender = dataRow["Gender"].ToString()
                                       };
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = from dataRow in DS.Tables["Students"].AsEnumerable()
                                       where dataRow["Name"].ToString().ToUpper().StartsWith(TextBox1.Text.ToUpper())
                                       select new Student
                                       {
                                           ID = Convert.ToInt32(dataRow["ID"]),
                                           TotalMarks = Convert.ToInt32(dataRow["TotalMarks"]),
                                           Name = dataRow["Name"].ToString(),
                                           Gender = dataRow["Gender"].ToString()
                                       };
                GridView1.DataBind();
            }
        }
    }
}