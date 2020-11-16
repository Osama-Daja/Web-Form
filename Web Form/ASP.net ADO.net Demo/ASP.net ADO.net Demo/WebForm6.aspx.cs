using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ASP.net_ADO.net_Demo
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand Com = new SqlCommand("Select ID,ProductName,UnitPrice from TBLProductsPriceRead", con);
                con.Open();

                using (SqlDataReader DR = Com.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Columns.Add("ID");
                    table.Columns.Add("Name");
                    table.Columns.Add("Price");
                    table.Columns.Add("DiscountedPrice");

                    while (DR.Read())
                    {
                        int Price = Convert.ToInt32(DR["UnitPrice"]);
                        double DisPriced = Price * 0.9;

                        DataRow Row = table.NewRow();
                        Row["ID"] = DR["ID"];
                        Row["Name"] = DR["ProductName"];
                        Row["Price"] = Price;
                        Row["DiscountedPrice"] = DisPriced;

                        table.Rows.Add(Row);

                    }

                    GridView1.DataSource = table;
                    GridView1.DataBind();
                }
            }
        }
    }
}