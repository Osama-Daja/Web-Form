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
    public partial class WebForm11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

            using(SqlConnection Con = new SqlConnection(CS))
            {
                string SQLQuery = "Select * From TBLStudents where ID = "+ TextBox4.Text;

                SqlDataAdapter DA = new SqlDataAdapter(SQLQuery, Con);
                DataSet DS = new DataSet();
                DA.Fill(DS, "Students");

                ViewState["SQLQuery"] = SQLQuery;
                ViewState["DATASET"] = DS;

                if (DS.Tables["Students"].Rows.Count > 0)
                {
                    DataRow DR = DS.Tables["Students"].Rows[0];
                    TextBox5.Text = DR["Name"].ToString();
                    DropDownList2.SelectedValue = DR["Gender"].ToString();
                    TextBox6.Text = DR["TotalMarks"].ToString();

                    Label10.ForeColor = System.Drawing.Color.Black;
                    Label10.Text = "You Get Data ID = " + TextBox4.Text;
                }
                else
                {
                    Label10.ForeColor = System.Drawing.Color.Red;
                    Label10.Text = "No Student Record With ID = " + TextBox4.Text;
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

            using (SqlConnection Con = new SqlConnection(CS))
            {
                string SQLQuery = "Select * From TBLStudents where ID = " + TextBox4.Text;

                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = new SqlCommand((string)ViewState["SQLQuery"], Con);

                SqlCommandBuilder builder = new SqlCommandBuilder(DA);
                DataSet DS = (DataSet)ViewState["DATASET"];
                
                if (DS.Tables["Students"].Rows.Count > 0)
                {
                    DataRow DR = DS.Tables["Students"].Rows[0];

                    DR["Name"] = TextBox5.Text;
                    DR["Gender"] = DropDownList2.SelectedValue;
                    DR["TotalMarks"] = TextBox6.Text;

                }
                int RowsUpdate = DA.Update(DS, "Students");
                if (RowsUpdate > 0)
                {
                    Label10.Text = RowsUpdate.ToString() + "Row(s) Updated";
                    Label10.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    Label10.ForeColor = System.Drawing.Color.Red;
                    Label10.Text = "No Row Update";
                }
                Label1.Text = builder.GetInsertCommand().CommandText.ToString();
            }
        }
    }
}