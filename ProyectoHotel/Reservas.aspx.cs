using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoHotel
{
    public partial class Reservas : System.Web.UI.Page
    {
        private static List<DateTime> fechasReservadas = new List<DateTime>();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                CargarHabitaciones();
            }
        }

        private void CargarHabitaciones()
        {
            HabitacionNegocio negocio = new HabitacionNegocio();
            List<Habitacion> lista = negocio.Listar();
            gvHabitaciones.DataSource = lista;
            gvHabitaciones.DataBind();
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            Habitacion nuevo = new Habitacion();
            HabitacionNegocio negocio = new HabitacionNegocio();
            try
            {
                nuevo.Numero = int.Parse(txtNumero.Text);
                nuevo.Capacidad = int.Parse(txtCapacidad.Text);
                nuevo.Estado = txtEstado.Text;
                nuevo.Activo = true;
                negocio.agregarConSP(nuevo);


                Response.Redirect("Reservas.aspx", false);
            }
            catch (Exception)
            {
                string script = "alert('Por favor, completa el campo.');";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
            }

        }

        protected void BtnRediReserva_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioReserva.aspx");
        }

       






        //// Evento para confirmar la reserva al hacer clic en el botón
        //protected void btnReservar_Click(object sender, EventArgs e)
        //{
        //    if (fechasReservadas.Count > 0)
        //    {
        //        GuardarReservasEnBaseDeDatos();
        //    }
        //    else
        //    {
        //        lblReservas.Text = "No hay fechas seleccionadas para reservar.";
        //    }
        //    lblReservas.Text = "Fechas reservadas: " + string.Join(", ", fechasReservadas.ConvertAll(f => f.ToString("dd/MM/yyyy")));
        //}

        //protected void btnLimpiar_Click(object sender, EventArgs e)
        //{
        //    // Limpiar la lista de fechas reservadas
        //    fechasReservadas.Clear();

        //    // Limpiar la selección del calendario
        //    Calendar1.SelectedDates.Clear();

        //    // Actualizar el label para mostrar que no hay reservas
        //    lblReservas.Text = "Ninguna";

        //    // Refrescar el calendario para mostrar cambios visuales
        //    Calendar1.DataBind();
        //}

        //private void GuardarReservasEnBaseDeDatos()
        //{
        //    AccesoDatos datos = new AccesoDatos();
        //    try
        //    {
        //        foreach (DateTime fecha in fechasReservadas)
        //        {
        //            datos.setearConsulta("INSERT INTO FechasReservadas (Fecha) VALUES (@fecha)");
        //            datos.setearParametro("@fecha", fecha);
        //            datos.ejecutarAccion();
        //        }

        //        // Limpiar la lista después de guardar en la base
        //        fechasReservadas.Clear();
        //        Calendar1.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        //}










    }
}
