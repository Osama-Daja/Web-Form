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
    public partial class WebForm12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void GetDataFromDataBase ()
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

            using (SqlConnection Con = new SqlConnection(CS))
            {
                string Query = "Select * From TBLStudents";
                SqlDataAdapter DA = new SqlDataAdapter(Query,Con);

                DataSet DataSet = new DataSet();
                DA.Fill(DataSet, "Students");

                DataSet.Tables["Students"].PrimaryKey = new DataColumn[] { DataSet.Tables["Students"].Columns["ID"] };
                Cache.Insert("DATASET",DataSet, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);

                GridView1.DataSource = DataSet;
                GridView1.DataBind();

                Label1.Text = "Data Loaded From Data Base";
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            GetDataFromDataBase();
        }

        private void GetDataFromCache()
        {
            if (Cache["DATASET"] != null)
            {
                DataSet dataSet = (DataSet)Cache["DATASET"];
                GridView1.DataSource = dataSet;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataSet dataSet = (DataSet)Cache["DATASET"];
            dataSet.Tables["Students"].Rows.Find(e.Keys["ID"]).Delete();

            Cache.Insert("DATASET", dataSet, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
            GetDataFromCache();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = GridView1.EditIndex;
            GetDataFromCache();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GetDataFromCache();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataSet dataSet = (DataSet)Cache["DATASET"];
            DataRow Row = dataSet.Tables["Students"].Rows.Find(e.Keys["ID"]);

            Row["Name"] = e.NewValues["Name"];
            Row["Gender"] = e.NewValues["Gender"];
            Row["TotalMarks"] = e.NewValues["TotalMarks"];

            Cache.Insert("DATASET", dataSet, null,DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);

            GridView1.EditIndex = -1;
            GetDataFromCache();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Cache["DATASET"] != null)
            {
                string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

                using (SqlConnection Con = new SqlConnection(CS))
                {
                    string Query = "Select * From TBLStudents";
                    SqlDataAdapter DA = new SqlDataAdapter(Query, Con);

                    string CommandUpdateString = "Update TBLStudents set Name = @Name,Gender = @Gender,TotalMarks = @TotalMarks where ID = @ID";
                    SqlCommand ComUpdate = new SqlCommand(CommandUpdateString, Con);

                    ComUpdate.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
                    ComUpdate.Parameters.Add("@Gender", SqlDbType.NVarChar, 20, "Gender");
                    ComUpdate.Parameters.Add("@TotalMarks", SqlDbType.Int, 0, "TotalMarks");
                    ComUpdate.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");

                    DA.UpdateCommand = ComUpdate;

                    string CommandDeleteString = "Delete From TBLStudents Where ID = @ID";
                    SqlCommand ComDelete = new SqlCommand(CommandDeleteString, Con);

                    //ComDelete.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
                    DA.DeleteCommand = ComDelete;

                    DA.Update((DataSet)Cache["DATASET"], "Students");
                    Label1.Text = "DataBase Table Update";

                }
            }
        }


        protected void Button3_Click(object sender, EventArgs e)
        {
            DataSet dataSet = (DataSet)Cache["DATASET"];

            
                if (dataSet.HasChanges())
                {
                    dataSet.RejectChanges();
                    Cache.Insert("DATASET", dataSet, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
                    GetDataFromCache();
                    Label1.Text = "Change Undone";
                    Label1.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    Label1.Text = "No Changes To Undo";
                    Label1.ForeColor = System.Drawing.Color.Red;
                }
                

            //
                /*
            foreach(DataRow row in dataSet.Tables["Students"].Rows)
            {
 
                if (row.RowState == DataRowState.Deleted)
                {
                    Response.Write(row["ID",DataRowVersion.Original].ToString() + " - " + row.RowState + "<br />");
                }else
                {
                    Response.Write(row["ID"].ToString() +  " - " + row.RowState + "<br />");
                }
                
            }*/
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            DataSet dataSet = (DataSet)Cache["DATASET"];

            dataSet.AcceptChanges();
            Cache.Insert("DATASET", dataSet, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
            GetDataFromCache();
        }
    }
}