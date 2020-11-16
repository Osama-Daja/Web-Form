using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.net_ADO.net_Demo
{
    public partial class WebForm16 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string SourceCS = ConfigurationManager.ConnectionStrings["SourceCS"].ConnectionString;
            string DestinationCS = ConfigurationManager.ConnectionStrings["DestinationCS"].ConnectionString;

            using (SqlConnection ConSource = new SqlConnection(SourceCS))
            {
                string ComSourceDepartments = "Select * From Departments";
                SqlCommand ComDepartments = new SqlCommand(ComSourceDepartments, ConSource);
                ConSource.Open();

                using (SqlDataReader RDR = ComDepartments.ExecuteReader())
                {
                    using (SqlConnection ConDepartments = new SqlConnection(DestinationCS))
                    {
                        ConDepartments.Open();
                        using (SqlBulkCopy bc = new SqlBulkCopy(ConDepartments))
                        {
                            bc.DestinationTableName = "Departments";
                            //ConDepartments.Open();
                            bc.WriteToServer(RDR);
                        }
                    }
                }

                string ComSourceEmployees = "Select * From Employees";
                SqlCommand ComEmployees = new SqlCommand(ComSourceEmployees, ConSource);
               // ConSource.Open();

                using (SqlDataReader RDR = ComEmployees.ExecuteReader())
                {
                    using (SqlConnection ConEmployees = new SqlConnection(DestinationCS))
                    {
                        ConEmployees.Open();
                        using (SqlBulkCopy bc = new SqlBulkCopy(ConEmployees))
                        {
                            bc.DestinationTableName = "Employees";
                            ConEmployees.Open();
                            bc.WriteToServer(RDR);
                        }
                    }
                }

            }
        }
    }
}