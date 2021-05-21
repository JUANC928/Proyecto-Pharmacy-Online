using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Pharmacy_Online.Masterpage
{
    public partial class Site2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["usuario"] = "";
            if (Session["usuario"].Equals("")) Response.Redirect("../Modulos/Entrada.aspx");
        }
    }
}