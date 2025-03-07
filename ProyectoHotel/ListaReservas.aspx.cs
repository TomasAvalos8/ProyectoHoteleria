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
        private string ID;
        private string DNI;
        private string Nombre;
        private string FechaI;
        private string FechaE;
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
                    CargarHabitaciones();
                }
            }
        }
        private void CargarReservas()
        {
            ReservaNegocio negocio = new ReservaNegocio();
            List<Reserva> lista = negocio.Listar();
            dgvReservas.DataSource = lista;
            dgvReservas.DataBind();

        }

        private void CargarHabitaciones()
        {
            HabitacionNegocio negocio = new HabitacionNegocio();
            List<Habitacion> listaHabitaciones = negocio.Listar();

            ddlHabitaciones.DataSource = listaHabitaciones;
            ddlHabitaciones.DataBind();

            ddlHabitaciones.Items.Insert(0, new ListItem("Seleccione una habitación", "0"));
        }
        private void CargarReservasPorHabitacion(int NroHabitacion)
        {
            ReservaNegocio negocio = new ReservaNegocio();
            List<Reserva> lista = negocio.Listar().Where(r => r.Numero_Habitacion == NroHabitacion).ToList();

            dgvReservas.DataSource = lista;
            dgvReservas.DataBind();

            fechasReservadas.Clear();
            foreach (var reserva in lista)
            {
                for (DateTime fecha = reserva.FechaIngreso; fecha <= reserva.FechaEgreso; fecha = fecha.AddDays(1))
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
                if (fechaSeleccionada >= reserva.FechaIngreso && fechaSeleccionada <= reserva.FechaEgreso)
                {
                    txtNroHabitacion.Text = reserva.Numero_Habitacion.ToString();
                    txtCapacidad.Text = reserva.Capacidad.ToString();
                    txtPrecio.Text = reserva.TotalReserva.ToString();
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
            if (e.Day.Date < DateTime.Today)
            {
                e.Cell.BackColor = System.Drawing.Color.LightGray;
                e.Cell.ForeColor = System.Drawing.Color.DarkGray;
                e.Cell.ToolTip = "Fecha no disponible";
            }
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
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = false;
            btnDetalles.Visible = false;
            ddlHabitaciones.SelectedIndex = 0;
            ReservaNegocio negocio = new ReservaNegocio();
            List<Reserva> lista = negocio.Listar();


            string filtroFecha = txtFiltroFecha.Text.Trim();
            string filtroNroHabitacion = txtFiltroNroHabitacion.Text.Trim();
            string filtroDNI = txtFiltroDNI.Text.Trim();

            //Filtro fecha
            if (!string.IsNullOrEmpty(filtroFecha) && DateTime.TryParse(filtroFecha, out DateTime fechaIngresada))
            {
                lista = lista.Where(r => r.FechaIngreso.Date <= fechaIngresada.Date && r.FechaEgreso.Date >= fechaIngresada.Date).ToList();
            }

            //filtro nro habitacion 
            if (!string.IsNullOrEmpty(filtroNroHabitacion) && int.TryParse(filtroNroHabitacion, out int nroHabitacion))
            {
                lista = lista.Where(r => r.Numero_Habitacion == nroHabitacion).ToList();
            }
            //filtro dni
            if (!string.IsNullOrEmpty(filtroDNI) && int.TryParse(filtroDNI, out int DNI))
            {
                lista = lista.Where(r => r.DNI_Huesped == DNI).ToList();
            }


            dgvReservas.DataSource = lista;
            dgvReservas.DataBind();
        }

        // Método para limpiar filtros y recargar todas las reservas
        protected void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtFiltroFecha.Text = "";
            txtFiltroNroHabitacion.Text = "";
            txtFiltroDNI.Text = "";
            CargarReservas(); // Recargar todas las reservas sin filtro
        }

        protected void dgvReservas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = dgvReservas.Rows[index];
            if (e.CommandName == "Editar")
            {
                string ID = row.Cells[0].Text;
                CargarReservaSession(ID);
                Response.Redirect("FormularioReserva.aspx?editar=true");
            }
            else if (e.CommandName == "Eliminar")
            {
                ID = row.Cells[0].Text;
                txtID.Text = ID;
                txtID.ReadOnly = true;
                DNI = row.Cells[1].Text;
                txtDniH.Text = DNI;
                txtDniH.ReadOnly = true;
                Nombre = row.Cells[2].Text;
                txtNombreH.Text = Nombre;
                txtNombreH.ReadOnly = true;
                FechaI = row.Cells[3].Text;
                txtFechaI.Text = FechaI;
                txtFechaI.ReadOnly = true;
                FechaE = row.Cells[4].Text;
                txtFechaE.Text = FechaE;
                txtFechaE.ReadOnly = true;

                string script = "abrirModal('EliminarReserva');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModal", script, true);
            }
        }

        protected void CargarReservaSession(string ID)
        {
            ReservaNegocio negocio = new ReservaNegocio();
            List<Reserva> lista = negocio.Listar();

            foreach (var reserva in lista)
            {
                if (ID == reserva.Id.ToString())
                {
                    Session["IdReserva"] = ID;
                    Session["NumeroHabitacion"] = reserva.Numero_Habitacion.ToString();
                    Session["Capacidad"] = reserva.Capacidad.ToString();
                    Session["TotalReserva"] = reserva.TotalReserva.ToString();
                    Session["DNI"] = reserva.DNI_Huesped.ToString();
                    Session["Nombre"] = reserva.Nombre_Huesped.ToString();
                    Session["Telefono"] = reserva.Telefono.ToString();
                    Session["FechaIngreso"] = reserva.FechaIngreso.ToString("dd/MM/yyyy");
                    Session["FechaEgreso"] = reserva.FechaEgreso.ToString("dd/MM/yyyy");
                    break;
                }
            }
        }
        protected void btnEReserva_Click(object sender, EventArgs e)
        {
            ReservaNegocio negocio = new ReservaNegocio();
            try
            {
                int Id = int.Parse(txtID.Text);

                negocio.eliminarConSP(Id);


                Response.Redirect("ListaReservas.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void ddlHabitaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calendar1.SelectedDate = DateTime.MinValue;
            if (ddlHabitaciones.SelectedIndex > 0)
            {
                int numero = int.Parse(ddlHabitaciones.SelectedValue);
                CargarReservasPorHabitacion(numero);
                Calendar1.Visible = true;
                btnDetalles.Visible = true;
                txtFiltroDNI.Text = "";
                txtFiltroFecha.Text = "";
                txtFiltroNroHabitacion.Text = "";
            }
        }


        protected void btnDetalles_Click(object sender, EventArgs e)
        {
            string script = "abrirModal('modalFechaSeleccionada');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModal", script, true);
        }
    }
}