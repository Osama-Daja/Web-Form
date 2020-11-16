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
    public partial class WebForm15 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

            using (SqlConnection Con = new SqlConnection(CS))
            {
                DataSet DS = new DataSet();
                DS.ReadXml(MapPath("~/Data.xml"));

                DataTable DT = DS.Tables["Department"];
                DataTable DE = DS.Tables["Employee"];

                Con.Open();
                using (SqlBulkCopy bc = new SqlBulkCopy(Con))
                {
                    bc.DestinationTableName = "Department";
                    bc.ColumnMappings.Add("ID", "ID");
                    bc.ColumnMappings.Add("Name", "Name");
                    bc.ColumnMappings.Add("Location", "Location");
                    bc.WriteToServer(DT);
                }

                using (SqlBulkCopy bc = new SqlBulkCopy(Con))
                {
                    bc.DestinationTableName = "Employee";
                    bc.ColumnMappings.Add("ID", "ID");
                    bc.ColumnMappings.Add("Name", "Name");
                    bc.ColumnMappings.Add("Gender", "Gender");
                    bc.WriteToServer(DE);
                }

            }

        }
    }
}