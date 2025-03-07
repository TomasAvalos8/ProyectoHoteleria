using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoHotel
{
    public partial class Configuracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                CrearUsuario user = new CrearUsuario();
                CrearUsuarioNegocio usuarioNegocio = new CrearUsuarioNegocio();
                user.Usuario = txtUsuer.Text;
                user.Pass = txtPass.Text;
                user.Tipo = 2;
                int id = usuarioNegocio.insertarNuevo(user);




            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}