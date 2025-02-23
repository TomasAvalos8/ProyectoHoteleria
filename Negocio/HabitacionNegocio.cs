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
                datos.setearConsulta("SELECT numero,Capacidad,Estado,Activo FROM Habitacion");
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
        public void AgregarHabitacion(string numero, string estado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Habitaciones (numero, estado) VALUES (@numero, @estado)");
                datos.setearParametro("@numero", numero);
                datos.setearParametro("@estado", estado);
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