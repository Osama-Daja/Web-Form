using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.net_SQL
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BTNDELETE.Enabled = false;
            }
        }

        protected void BTNCLEAR_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            hfContactID.Value = "";
            TXTName.Text = TxTMobile.Text = TxtAddress.Text = "";
            lblErrorMassage.Text = lblSucssesMassage.Text = "";
            BTNSAVE.Text = "Save";
            BTNDELETE.Enabled = false;
        }
    }
}