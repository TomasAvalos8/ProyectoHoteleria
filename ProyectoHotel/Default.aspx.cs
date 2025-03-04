using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoHotel
{
    public partial class Default : System.Web.UI.Page
    {
        private static List<DateTime> fechasReservadas = new List<DateTime>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["logout"] == "true")
            {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }

            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes iniciar sesión para ingresar");
                Response.Redirect("Login.aspx");
            }


        }
    }
}