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
    public partial class WebForm17 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

            using (SqlConnection Con = new SqlConnection(CS))
            {
                SqlCommand Com = new SqlCommand("Select * From Table_1", Con);
                Con.Open();

                using (SqlDataReader RDR = Com.ExecuteReader())
                {
                    using (SqlConnection Con2 = new SqlConnection(CS))
                    {
                        using (SqlBulkCopy bc = new SqlBulkCopy(Con2))
                        {
                            Con2.Open();
                            bc.BatchSize = 30000;
                            bc.NotifyAfter = 5000;
                            //bc.SqlRowsCopied += Bc_SqlRowsCopied;
                            bc.SqlRowsCopied += Bc_SqlRowsCopied;
                            bc.DestinationTableName = "Table_1";
                            bc.WriteToServer(RDR);
                        }
                    }
                }
            }
        }

        private void Bc_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            Console.WriteLine(e.RowsCopied + "Loaded ... ");
        }
    }
}