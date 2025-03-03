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
                    Response.Redirect("Default.aspx",false);
                }
                else
                {
                    Session.Add("Error", "Usuario o Contraseña Incorrectos");
                    Response.Redirect("Error.aspx");
                }

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
            }
        }

    }
}