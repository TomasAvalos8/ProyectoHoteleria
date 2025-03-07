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
                datos.setearConsulta("SELECT Numero,Capacidad,Estado,Activo,PrecioBase FROM Habitacion");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Habitacion habitacion = new Habitacion
                    {
                        Numero = (int)datos.Lector["Numero"],
                        Capacidad = (int)datos.Lector["Capacidad"],
                        PrecioBase = (decimal)datos.Lector["PrecioBase"],
                        Estado = datos.Lector["Estado"].ToString(),
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
                datos.setearParametro("@PrecioBase", nuevo.PrecioBase);
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
        public void modificarConSP(Habitacion modificada)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_ModificarHabitacion");
                datos.setearParametro("@Numero", modificada.Numero);
                datos.setearParametro("@Capacidad", modificada.Capacidad);
                datos.setearParametro("@PrecioBase", modificada.PrecioBase);
                datos.setearParametro("@Estado", modificada.Estado);
                datos.setearParametro("@Activo", modificada.Activo);

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
        public void eliminarConSP(int numeroHabitacion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_EliminarHabitacion");
                datos.setearParametro("@Numero", numeroHabitacion);
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