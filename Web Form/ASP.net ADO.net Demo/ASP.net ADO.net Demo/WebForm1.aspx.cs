using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ASP.net_ADO.net_Demo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection("data source = OSAMA-AL-DAJA; database = ADO.NET; integrated security = SSPI");
            SqlCommand Cmd = new SqlCommand("Select * from TBLProducts",Con);
            Con.Open();

            SqlDataReader RDR = Cmd.ExecuteReader();

            GridView1.DataSource = RDR;
            GridView1.DataBind();

            Con.Close();

        }
    }
}