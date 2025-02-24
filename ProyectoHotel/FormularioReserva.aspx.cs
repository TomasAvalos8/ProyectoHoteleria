using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoHotel
{
    public partial class FormularioReserva : System.Web.UI.Page
    {
        private static DateTime? fechaIngreso = null;
        private static DateTime? fechaEgreso = null;
        private static List<DateTime> fechasReservadas = new List<DateTime>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fechasReservadas.Clear();
                fechaIngreso = null;
                fechaEgreso = null;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = Calendar1.SelectedDate;

            if (!fechaIngreso.HasValue)
            {
                fechaIngreso = fechaSeleccionada;
                fechaEgreso = null;
                fechasReservadas.Clear();
                fechasReservadas.Add(fechaSeleccionada);
            }
            else if (!fechaEgreso.HasValue)
            {
                fechaEgreso = fechaSeleccionada;
                fechasReservadas.Clear();

                if (fechaIngreso > fechaEgreso)
                {
                    // Intercambiar si la segunda fecha es anterior a la primera
                    DateTime aux = fechaIngreso.Value;
                    fechaIngreso = fechaEgreso;
                    fechaEgreso = aux;
                }

                // Agregar todas las fechas en el rango
                for (DateTime date = fechaIngreso.Value; date <= fechaEgreso.Value; date = date.AddDays(1))
                {
                    fechasReservadas.Add(date);
                }
            }
            else
            {
                // Si ya hay dos fechas seleccionadas, reiniciar
                fechaIngreso = fechaSeleccionada;
                fechaEgreso = null;
                fechasReservadas.Clear();
                fechasReservadas.Add(fechaSeleccionada);
            }

            ActualizarFechasTextBox();
            //Calendar1.DataBind();
        }

        private void ActualizarFechasTextBox()
        {
            txtFechaIngreso.Text = fechaIngreso.HasValue ? fechaIngreso.Value.ToShortDateString() : string.Empty;
            txtFechaEgreso.Text = fechaEgreso.HasValue ? fechaEgreso.Value.ToShortDateString() : string.Empty;
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (fechasReservadas.Contains(e.Day.Date))
            {
                e.Cell.BackColor = System.Drawing.Color.LightGreen;
                e.Cell.ForeColor = System.Drawing.Color.White;
                e.Cell.ToolTip = "Reservado";
            }
            if (e.Day.Date < DateTime.Today)
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.LightGray;
                e.Cell.ForeColor = System.Drawing.Color.DarkGray;
                e.Cell.ToolTip = "Fecha no disponible";
            }
        }

        protected void btnGuardarReserva_Click(object sender, EventArgs e)
        {
            try
            {
                int dniHuesped = int.Parse(txtDNI.Text);
                int numeroHabitacion = int.Parse(txtNroHabitacion.Text);
                DateTime fechaIngreso = DateTime.Parse(txtFechaIngreso.Text);
                DateTime fechaEgreso = DateTime.Parse(txtFechaEgreso.Text);

                AgregarReserva(dniHuesped, numeroHabitacion, fechaIngreso, fechaEgreso);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        public void AgregarReserva(int dniHuesped, int numeroHabitacion, DateTime fechaIngreso, DateTime fechaEgreso)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearProcedimiento("InsertarReserva");
                accesoDatos.setearParametro("@DNI_Huesped", dniHuesped);
                accesoDatos.setearParametro("@Numero_Habitacion", numeroHabitacion);
                accesoDatos.setearParametro("@FechaIngreso", fechaIngreso);
                accesoDatos.setearParametro("@FechaEgreso", fechaEgreso);
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