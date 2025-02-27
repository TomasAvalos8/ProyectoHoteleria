using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public bool Loguear(Usuario usuario)
        {
            try
            {
                datos.setearConsulta("Select Id, Usuario, Contraseña, Administrador FROM Usuarios where Usuario = @User AND Contraseña = @Pass");
                datos.setearParametro("@User", usuario.User);
                datos.setearParametro("@Pass", usuario.Pass);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.tipoUsuario = (int)(datos.Lector["Administrador"]) == 2 ? TipoUsuario.Admin : TipoUsuario.Normal;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}