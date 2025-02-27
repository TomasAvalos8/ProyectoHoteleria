using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio;
using Negocio;

namespace Dominio
{
    public class HabitacionNegocio
    {
        public List<Habitacion> Listar()
        {
            List<Habitacion> lista = new List<Habitacion>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Numero,Capacidad,Estado,Activo FROM Habitacion");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Habitacion habitacion = new Habitacion
                    {
                        Numero= (int)datos.Lector["Numero"],
                        Capacidad= (int)datos.Lector["Capacidad"],
                        Estado= datos.Lector["Estado"].ToString(),
                        Activo = (bool)datos.Lector["Activo"],


                    };

                    lista.Add(habitacion);
                }

                return lista;
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
        public void agregarConSP(Habitacion nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_AgregarHabitacion");
                datos.setearParametro("@Numero", nuevo.Numero);
                datos.setearParametro("@Capacidad", nuevo.Capacidad);
                datos.setearParametro("@Estado", nuevo.Estado);
                datos.setearParametro("@Activo", nuevo.Activo);

                datos.ejecutarAccion();
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