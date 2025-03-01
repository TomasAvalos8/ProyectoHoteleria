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
                datos.setearConsulta(@"SELECT r.Id, r.DNI_Huesped, h.NombreCompleto, r.Numero_Habitacion, r.FechaIngreso, r.FechaEgreso
            FROM Reserva r
            INNER JOIN Huesped h ON r.DNI_Huesped = h.DNI");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Reserva reserva = new Reserva
                    {
                        Id = (int)datos.Lector["Id"],
                        DNI_Huesped = (int)datos.Lector["DNI_Huesped"],
                        Nombre_Huesped = datos.Lector["NombreCompleto"].ToString(),
                        Numero_Habitacion = (int)datos.Lector["Numero_Habitacion"],
                        FechaIngreso = (DateTime)datos.Lector["FechaIngreso"],
                        FechaEgreso = (DateTime)datos.Lector["FechaEgreso"]



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
    }
}