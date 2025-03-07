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
    public partial class FormularioReserva : System.Web.UI.Page
    {
        private static DateTime? fechaIngreso = null;
        private static DateTime? fechaEgreso = null;
        private static List<DateTime> fechasSeleccionadas = new List<DateTime>();
        private static List<DateTime> fechasReservadas = new List<DateTime>();
        private static List<DateTime> fechasReservadasActual = new List<DateTime>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {

                Session.Add("error", "debes iniciar sesion para ingresar");
                Response.Redirect("Login.aspx", false);



            }
            else
            {
                fechasReservadasActual.Clear();
                if (!IsPostBack)
                {
                    bool esEdicion = Request.QueryString["editar"] == "true";
                    string numeroHabitacion = Session["NumeroHabitacion"] as string;
                    string capacidad = Session["Capacidad"] as string;
                    string precio = Session["TotalReserva"] as string;
                    string estado = Session["Estado"] as string;
                    if (esEdicion)
                    {
                        string dni = Session["DNI"] as string;
                        string nombre = Session["Nombre"] as string;
                        string telefono = Session["Telefono"] as string;
                        string fechaingreso = Session["FechaIngreso"] as string;
                        string fechaegreso = Session["FechaEgreso"] as string;
                        txtNroHabitacion.Text = numeroHabitacion;
                        txtNroHabitacion.ReadOnly = true;
                        txtCapacidad.Text = capacidad;
                        txtCapacidad.ReadOnly = true;
                        txtPrecio.Text = precio;
                        txtPrecio.ReadOnly = true;
                        txtDNI.Text = dni;
                        txtDNI.ReadOnly = true;
                        txtNombre.Visible = true;
                        txtNombre.ReadOnly = true;
                        lblNombre.Visible = true;
                        txtTelefono.Visible = true;
                        txtTelefono.ReadOnly = true;
                        lblTelefono.Visible = true;
                        txtNombre.Text = nombre;
                        txtTelefono.Text = telefono;
                        txtFechaIngreso.Text = fechaingreso;
                        txtFechaEgreso.Text = fechaegreso;
                        btnEditarReserva.Visible = true;
                        btnGuardarReserva.Visible = false;
                        fechaIngreso = Convert.ToDateTime(Session["FechaIngreso"]);
                        fechaEgreso = Convert.ToDateTime(Session["FechaEgreso"]);

                        // Agregar las fechas de la reserva a la lista
                        fechasReservadasActual.Clear();
                        for (DateTime date = fechaIngreso.Value; date <= fechaEgreso.Value; date = date.AddDays(1))
                        {
                            fechasReservadasActual.Add(date);
                        }
                    }
                    else
                    {


                        txtNroHabitacion.Text = numeroHabitacion;
                        txtNroHabitacion.ReadOnly = true;
                        txtCapacidad.Text = capacidad;
                        txtCapacidad.ReadOnly = true;
                        txtPrecio.Text = precio;
                        txtPrecio.ReadOnly = true;
                        txtDNI.Text = "";
                        txtNombre.Text = "";
                        txtTelefono.Text = "";
                        txtFechaIngreso.Text = "";
                        txtFechaEgreso.Text = "";
                        txtNombre.Visible = false;
                        lblNombre.Visible = false;
                        txtTelefono.Visible = false;
                        lblTelefono.Visible = false;
                    }
                    CargarReservas();
                    fechasSeleccionadas.Clear();
                    fechaIngreso = null;
                    fechaEgreso = null;

                }
            }
        }
        private void CargarReservas()
        {
            ReservaNegocio negocio = new ReservaNegocio();
            List<Reserva> lista = negocio.Listar();


            fechasReservadas.Clear();

            // Agregar las fechas reservadas al calendario
            foreach (var reserva in lista)
            {
                DateTime fechaIngreso = reserva.FechaIngreso;
                DateTime fechaEgreso = reserva.FechaEgreso;
                int Numero = reserva.Numero_Habitacion;
                int numeroHabitacion;
                if (int.TryParse(txtNroHabitacion.Text, out numeroHabitacion) && numeroHabitacion == Numero)
                {
                    {
                        for (DateTime fecha = fechaIngreso; fecha <= fechaEgreso; fecha = fecha.AddDays(1))
                        {
                            fechasReservadas.Add(fecha);
                        }
                    }
                }
            }
        }


        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = Calendar1.SelectedDate;

            if (!fechaIngreso.HasValue)
            {
                fechaIngreso = fechaSeleccionada;
                fechaEgreso = null;
                fechasSeleccionadas.Clear();
                fechasSeleccionadas.Add(fechaSeleccionada);
            }
            else if (!fechaEgreso.HasValue)
            {
                fechaEgreso = fechaSeleccionada;
                fechasSeleccionadas.Clear();

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
                    fechasSeleccionadas.Add(date);
                }
            }
            else
            {
                // Si ya hay dos fechas seleccionadas, reiniciar
                fechaIngreso = fechaSeleccionada;
                fechaEgreso = null;
                fechasSeleccionadas.Clear();
                fechasSeleccionadas.Add(fechaSeleccionada);
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
            bool esFechaDeLaReservaActual = fechasReservadasActual.Contains(e.Day.Date);
            if (fechasSeleccionadas.Contains(e.Day.Date))
            {
                e.Cell.BackColor = System.Drawing.Color.LightGreen;
                e.Cell.ForeColor = System.Drawing.Color.White;
                e.Cell.ToolTip = "Seleccionado";
            }
            else if (fechasReservadas.Contains(e.Day.Date) && !esFechaDeLaReservaActual)
            {
                e.Cell.BackColor = System.Drawing.Color.DarkRed;
                e.Cell.ForeColor = System.Drawing.Color.White;
                e.Day.IsSelectable = false;
                e.Cell.ToolTip = "Reservado";
            }
            else if (e.Day.Date < DateTime.Today)
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.LightGray;
                e.Cell.ForeColor = System.Drawing.Color.DarkGray;
                e.Cell.ToolTip = "Fecha no disponible";
            }
        }

        protected void btnGuardarReserva_Click(object sender, EventArgs e)
        {
            Reserva nuevo = new Reserva();
            ReservaNegocio negocio = new ReservaNegocio();
            try
            {
                nuevo.Numero_Habitacion = int.Parse(txtNroHabitacion.Text);
                nuevo.DNI_Huesped = int.Parse(txtDNI.Text);
                string nombre = txtNombre.Text;
                string telefono = txtTelefono.Text;
                nuevo.FechaIngreso = DateTime.Parse(txtFechaIngreso.Text);
                nuevo.FechaEgreso = DateTime.Parse(txtFechaEgreso.Text);

                foreach (DateTime fecha in fechasSeleccionadas)
                {
                    if (fechasReservadas.Contains(fecha))
                    {
                        Session["ErrorMensaje"] = "Alguna de las fechas seleccionadas ya está reservada.";
                        Response.Redirect("Error.aspx");
                    }
                }

                decimal precioBase;
                if (!decimal.TryParse(txtPrecio.Text, out precioBase))
                {
                    Response.Write("<script>alert('Error: El precio de la habitación no es válido.');</script>");
                    return;
                }

                int totalDias = (nuevo.FechaEgreso - nuevo.FechaIngreso).Days +1;
                if (totalDias <= 0)
                {
                    Response.Write("<script>alert('Error: La fecha de egreso debe ser posterior a la fecha de ingreso.');</script>");
                    return;
                }

                decimal totalReserva = precioBase * totalDias;

                nuevo.TotalReserva = totalReserva;

                if (!validarDNI(nuevo.DNI_Huesped))
                {
                    AgregarHuesped(nuevo.DNI_Huesped, nombre, telefono);
                }

                negocio.AgregarReserva(nuevo);


                Response.Redirect("ListaReservas.aspx", false);
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

        public void AgregarHuesped(int dniHuesped, string nombre, string telefono)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("Insert into Huesped (DNI,NombreCompleto,Telefono)VALUES(@DNI,@NombreCompleto,@Telefono)");
                accesoDatos.setearParametro("@DNI", dniHuesped);
                accesoDatos.setearParametro("@NombreCompleto", nombre);
                accesoDatos.setearParametro("@Telefono", telefono);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el huesped: " + ex.Message);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        protected void txtDNI_TextChanged(object sender, EventArgs e)
        {
            int DNI = int.Parse(txtDNI.Text);

            validarDNI(DNI);

        }


        public bool validarDNI(int DNI)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearConsulta("SELECT DNI,NombreCompleto,Telefono FROM Huesped WHERE DNI = @DNI");
                datos.setearParametro("@DNI", DNI);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    txtDNI.Enabled = false;
                    txtNombre.Text = (string)datos.Lector["NombreCompleto"];
                    txtNombre.Enabled = false;
                    lblNombre.Visible = true;
                    txtNombre.Visible = true;
                    txtTelefono.Text = (string)datos.Lector["Telefono"];
                    txtTelefono.Enabled = false;
                    lblTelefono.Visible = true;
                    txtTelefono.Visible = true;

                    return true;

                }
                lblNombre.Visible = true;
                txtNombre.Visible = true;
                lblTelefono.Visible = true;
                txtTelefono.Visible = true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        protected void txtNroHabitacion_TextChanged(object sender, EventArgs e)
        {
            CargarReservas();
        }

        protected void btnEditarReserva_Click(object sender, EventArgs e)
        {
            Reserva modificada = new Reserva();
            ReservaNegocio negocio = new ReservaNegocio();
            try
            {
                modificada.Id = Convert.ToInt32(Session["IdReserva"]);
                modificada.DNI_Huesped = int.Parse(txtDNI.Text);
                modificada.Nombre_Huesped = txtNombre.Text;
                modificada.Telefono = txtTelefono.Text;
                modificada.Numero_Habitacion = int.Parse(txtNroHabitacion.Text);
                modificada.Capacidad = int.Parse(txtCapacidad.Text);
                modificada.TotalReserva = Decimal.Parse(txtPrecio.Text);
                modificada.FechaIngreso = DateTime.Parse(txtFechaIngreso.Text);
                modificada.FechaEgreso = DateTime.Parse(txtFechaEgreso.Text);
                modificada.Activo = true;
                negocio.editarConSP(modificada);


                Response.Redirect("ListaReservas.aspx", false);
            }
            catch (Exception)
            {
                string script = "alert('Por favor, completa el campo.');";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
            }
        }

      
    }
}