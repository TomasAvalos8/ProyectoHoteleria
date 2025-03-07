using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Negocio
{
    public class ReservaNegocio
    {

        public List<Reserva> Listar()
        {
            List<Reserva> lista = new List<Reserva>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"SELECT hab.Capacidad, r.Id, r.DNI_Huesped, h.NombreCompleto,h.Telefono, r.Numero_Habitacion, r.FechaIngreso, r.FechaEgreso,r.TotalReserva
            FROM Reserva r
            INNER JOIN Huesped h ON r.DNI_Huesped = h.DNI
            INNER JOIN Habitacion hab ON r.Numero_Habitacion = hab.Numero");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Reserva reserva = new Reserva
                    {
                        Id = (int)datos.Lector["Id"],
                        DNI_Huesped = (int)datos.Lector["DNI_Huesped"],
                        Nombre_Huesped = datos.Lector["NombreCompleto"].ToString(),
                        Telefono = datos.Lector["Telefono"].ToString(),
                        Numero_Habitacion = (int)datos.Lector["Numero_Habitacion"],
                        Capacidad = (int)datos.Lector["Capacidad"],
                        FechaIngreso = (DateTime)datos.Lector["FechaIngreso"],
                        FechaEgreso = (DateTime)datos.Lector["FechaEgreso"],
                        TotalReserva = (decimal)datos.Lector["TotalReserva"]


                    };

                    lista.Add(reserva);
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

        public void AgregarReserva(Reserva nuevo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearProcedimiento("InsertarReserva");
                accesoDatos.setearParametro("@DNI_Huesped", nuevo.DNI_Huesped);
                accesoDatos.setearParametro("@Numero_Habitacion", nuevo.Numero_Habitacion);
                accesoDatos.setearParametro("@FechaIngreso", nuevo.FechaIngreso);
                accesoDatos.setearParametro("@FechaEgreso", nuevo.FechaEgreso);
                accesoDatos.setearParametro("@TotalReserva", nuevo.TotalReserva);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la reserva: " + ex.Message);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public void eliminarConSP(int ID)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_EliminarReserva");
                datos.setearParametro("@Id", ID);
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
        public void editarConSP(Reserva modificada)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("ModificarReserva");
                datos.setearParametro("@idReserva", modificada.Id);
                datos.setearParametro("@DNI_Huesped", modificada.DNI_Huesped);
                datos.setearParametro("@Numero_habitacion", modificada.Numero_Habitacion);
                datos.setearParametro("@FechaIngreso", modificada.FechaIngreso);
                datos.setearParametro("@FechaEgreso", modificada.FechaEgreso);
                datos.setearParametro("@TotalReserva", modificada.TotalReserva);
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