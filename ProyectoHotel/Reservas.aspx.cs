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
            //if (!IsPostBack)
            //{
            //    lblReservas.Text = "Ninguna";
            //}
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
                nuevo.Numero =int.Parse(txtNumero.Text);
                nuevo.Capacidad =int.Parse(txtCapacidad.Text);
                nuevo.Estado =txtEstado.Text;
                negocio.agregarConSP(nuevo);


                Response.Redirect("Reservas.aspx", false);
            }
            catch (Exception)
            {
                string script = "alert('Por favor, completa el campo.');";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
            }

        }


        //protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        //{

        //    DateTime fechaSeleccionada = Calendar1.SelectedDate;

        //    // Si la fecha ya está reservada, la quitamos (desseleccionar)
        //    if (fechasReservadas.Contains(fechaSeleccionada))
        //    {
        //        fechasReservadas.Remove(fechaSeleccionada);
        //    }
        //    else
        //    {
        //        // Si la fecha no está reservada, la agregamos
        //        fechasReservadas.Add(fechaSeleccionada);
        //    }

        //    Calendar1.SelectedDates.Clear();

        //    // Actualizamos el label con las fechas reservadas
        //    lblReservas.Text = fechasReservadas.Count > 0
        //        ? string.Join(", ", fechasReservadas.ConvertAll(f => f.ToString("dd/MM/yyyy")))
        //        : "Ninguna";

        //    // Refrescar el calendario para mostrar cambios visuales
        //    Calendar1.DataBind();
        //}

        //// Evento para personalizar la apariencia del calendario
        //protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        //{
        //    if (fechasReservadas.Contains(e.Day.Date))
        //    {
        //        //e.Day.IsSelectable = false;
        //        e.Cell.BackColor = System.Drawing.Color.LightGreen; // Pinta en verde las fechas reservadas
        //        e.Cell.ForeColor = System.Drawing.Color.White;
        //        e.Cell.ToolTip = "Reservado";
        //    }
        //    // Deshabilitar fechas pasadas
        //    if (e.Day.Date < DateTime.Today)
        //    {
        //        e.Day.IsSelectable = false; // No se puede seleccionar
        //        e.Cell.BackColor = System.Drawing.Color.LightGray; // Fondo gris para diferenciar
        //        e.Cell.ForeColor = System.Drawing.Color.DarkGray; // Texto gris
        //        e.Cell.ToolTip = "Fecha no disponible"; // Tooltip informativo
        //    }
        //}

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
