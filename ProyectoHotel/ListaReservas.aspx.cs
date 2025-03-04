using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoHotel
{
    public partial class ListaReservas : System.Web.UI.Page
    {
        private static DateTime? fechaIngreso = null;
        private static DateTime? fechaEgreso = null;
        private static List<DateTime> fechasReservadas = new List<DateTime>();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["usuario"] == null)
            {

                Session.Add("error", "debes iniciar sesion para ingresar");
                Response.Redirect("Login.aspx", false);



            }
            else
            {
                if (!IsPostBack)
                {
                    CargarReservas();
                }
            }
        }
        private void CargarReservas()
        {
            ReservaNegocio negocio = new ReservaNegocio();
            List<Reserva> lista = negocio.Listar();
            dgvReservas.DataSource = lista;
            dgvReservas.DataBind();

            fechasReservadas.Clear();

            // Agregar las fechas reservadas al calendario
            foreach (var reserva in lista)
            {
                DateTime fechaIngreso = reserva.FechaIngreso;
                DateTime fechaEgreso = reserva.FechaEgreso;

                for (DateTime fecha = fechaIngreso; fecha <= fechaEgreso; fecha = fecha.AddDays(1))
                {
                    fechasReservadas.Add(fecha);
                }
            }
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = Calendar1.SelectedDate;

            DetallesReserva(fechaSeleccionada);

        }

        protected void DetallesReserva(DateTime fechaSeleccionada)
        {
            ReservaNegocio negocio = new ReservaNegocio();
            List<Reserva> lista = negocio.Listar();
            
            foreach (var reserva in lista)
            {
                if (fechaSeleccionada>=reserva.FechaIngreso && fechaSeleccionada<=reserva.FechaEgreso)
                {
                    txtNroHabitacion.Text = reserva.Numero_Habitacion.ToString();
                    txtCapacidad.Text = reserva.Capacidad.ToString();
                    //txtPrecio.Text = reserva..ToString();
                    txtDNI.Text = reserva.DNI_Huesped.ToString();
                    txtNombre.Text = reserva.Nombre_Huesped.ToString();
                    txtTelefono.Text = reserva.Telefono.ToString();
                    txtFechaIngreso.Text = reserva.FechaIngreso.ToString("dd/MM/yyyy");
                    txtFechaEgreso.Text = reserva.FechaEgreso.ToString("dd/MM/yyyy");
                    break;
                }
            }
        }
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (fechasReservadas.Contains(e.Day.Date))
            {
                e.Cell.BackColor = System.Drawing.Color.DarkRed;
                e.Cell.ForeColor = System.Drawing.Color.White;
                e.Cell.ToolTip = "Reservado";
            }
            if (!fechasReservadas.Contains(e.Day.Date))
            {
                e.Day.IsSelectable = false;
            }
            if (e.Day.Date < DateTime.Today)
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.LightGray;
                e.Cell.ForeColor = System.Drawing.Color.DarkGray;
                e.Cell.ToolTip = "Fecha no disponible";
            }
        }
    }
}