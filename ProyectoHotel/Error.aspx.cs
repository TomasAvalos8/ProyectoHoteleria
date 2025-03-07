using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoHotel
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtError.Text = "";
            if (Session["ErrorMensaje"] != null)
            {
                string errorMensaje = Session["ErrorMensaje"].ToString();
                txtError.Text = "Error: " + errorMensaje;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reservas.aspx");
        }
    }
}
