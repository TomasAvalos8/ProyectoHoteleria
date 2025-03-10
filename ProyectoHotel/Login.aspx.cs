﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace ProyectoHotel
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario;
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                usuario = new Usuario(txtUsuario.Text, txtContraseña.Text, false);
                if (negocio.Loguear(usuario))
                {
                    Session.Add("Usuario", usuario);
                    Response.Redirect("Reservas.aspx", false);
                }
                else
                {
                    Session.Add("ErrorMensaje", "Usuario o Contraseña Incorrectos");
                    Response.Redirect("Error.aspx");
                }

            }
            catch (Exception ex)
            {

                Session.Add("ErrorMensaje", ex.Message);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioRegistro.aspx", false);
        }
    }
}