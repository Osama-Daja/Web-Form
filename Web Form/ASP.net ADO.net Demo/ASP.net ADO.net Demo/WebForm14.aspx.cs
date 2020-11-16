using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.net_ADO.net_Demo
{
    public partial class WebForm14 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                StudentsDataSetTableAdapters.TBLStudentsTableAdapter studentsTableAdapter = new StudentsDataSetTableAdapters.TBLStudentsTableAdapter();
                StudentsDataSet.TBLStudentsDataTable tBLStudents = new StudentsDataSet.TBLStudentsDataTable();

                studentsTableAdapter.Fill(tBLStudents);

                Session["DATASET"] = tBLStudents;
                GridView1.DataSource = from Student in tBLStudents
                                       select new
                                       { Student.ID, Student.Name, Student.Gender, Student.TotalMarks };
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StudentsDataSet.TBLStudentsDataTable tBLStudents = new StudentsDataSet.TBLStudentsDataTable();
            tBLStudents = (StudentsDataSet.TBLStudentsDataTable)Session["DATASET"];

            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                GridView1.DataSource = from Student in tBLStudents
                                       select new
                                       { Student.ID, Student.Name, Student.Gender, Student.TotalMarks };
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = from Student in tBLStudents
                                       where Student.Name.ToUpper().StartsWith(TextBox1.ToString())
                                       select new
                                       { Student.ID, Student.Name, Student.Gender, Student.TotalMarks };
                GridView1.DataBind();
            }
        }
    }
}