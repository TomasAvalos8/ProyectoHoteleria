﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio;
namespace Negocio
{
	public class CrearUsuarioNegocio
	{

        public int insertarNuevo(CrearUsuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("insertarNuevo");
                datos.setearParametro("@user", nuevo.Usuario);
                datos.setearParametro("@pass", nuevo.Pass);
                datos.setearParametro("@Administrador", nuevo.Tipo);
                return datos.ejecutarAccionScalar();

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