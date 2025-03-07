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
        private string numeroHabitacion;
        private string capacidad;
        private string estado;
        private string precio;

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
                    lblError.Visible = false;
                    CargarHabitaciones();
                }
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
                if (string.IsNullOrEmpty(txtNumero.Text) ||
                    string.IsNullOrEmpty(txtCapacidad.Text) ||
                     string.IsNullOrEmpty(txtPrecioBase.Text))
                {
                    lblError.Text = "Todos los campos son obligatorios.";
                    lblError.Visible = true;
                    string script = "abrirModal('formularioModalAgregarHabitacion');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModal", script, true);
                }
                else
                {
                    nuevo.Numero = int.Parse(txtNumero.Text);
                    nuevo.Capacidad = int.Parse(txtCapacidad.Text);
                    nuevo.Estado = ddlEstado.SelectedValue;
                    nuevo.PrecioBase = decimal.Parse(txtPrecioBase.Text);
                    nuevo.Activo = true;

                    negocio.agregarConSP(nuevo);

                    Response.Redirect("Reservas.aspx", false);
                }
            }
            catch (SqlException ex) 
            {
                Session.Add("ErrorMensaje", ex.Message);
                Response.Redirect("Error.aspx");
            }
            catch (FormatException ex)
            {

                Session.Add("ErrorMensaje", ex.Message);
                Response.Redirect("Error.aspx");
            }
            catch (Exception ex)
            {

                Session.Add("ErrorMensaje", ex.Message);
                Response.Redirect("Error.aspx");
            }
        }


        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Habitacion modificada = new Habitacion();
            HabitacionNegocio negocio = new HabitacionNegocio();
            try
            {
                if (string.IsNullOrEmpty(txtCapacidad.Text) ||
                         string.IsNullOrEmpty(txtPrecioBase.Text))
                {
                    lblError.Text = "Todos los campos son obligatorios.";
                    lblError.Visible = true;
                    string script = "abrirModal('formularioModalAgregarHabitacion');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModal", script, true);
                }
                else
                {
                    modificada.Numero = int.Parse(txtNumero.Text);
                    modificada.Capacidad = int.Parse(txtCapacidad.Text);
                    modificada.PrecioBase = decimal.Parse(txtPrecioBase.Text);
                    modificada.Estado = ddlEstado.SelectedValue;
                    modificada.Activo = true;
                    negocio.modificarConSP(modificada);

                    Response.Redirect("Reservas.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("ErrorMensaje", ex.Message);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnEHabitacion_Click(object sender, EventArgs e)
        {
            
            HabitacionNegocio negocio = new HabitacionNegocio();
            try
            {
                int Numero = int.Parse(txtNro.Text);
            
                negocio.eliminarConSP(Numero);


                Response.Redirect("Reservas.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("ErrorMensaje", ex.Message);
                Response.Redirect("Error.aspx");
            }
        }


        protected void gvHabitaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            int index = Convert.ToInt32(e.CommandArgument);


            GridViewRow row = gvHabitaciones.Rows[index];


            if (e.CommandName == "Agregar")
            {
                
                Session["NumeroHabitacion"] = row.Cells[1].Text;
                Session["Capacidad"] = row.Cells[2].Text;
                Session["Estado"] = row.Cells[3].Text;
                Session["TotalReserva"] = row.Cells[4].Text;
                Response.Redirect("FormularioReserva.aspx");

            }
             if (e.CommandName == "Editar")
            {
                numeroHabitacion = row.Cells[1].Text;
                capacidad = row.Cells[2].Text;
                estado = row.Cells[3].Text;
                precio = row.Cells[4].Text;
                txtNumero.Text = numeroHabitacion;
                txtNumero.ReadOnly = true;
                txtCapacidad.Text = capacidad;
                ddlEstado.SelectedValue = estado;
                txtPrecioBase.Text = precio;
                btnaceptar.Visible = false;
                btnEditar.Visible = true;
                tituloAgregar.Style["display"] = "none";
                tituloEditar.Style["display"] = "block";
                string script = "abrirModal('formularioModalAgregarHabitacion');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModal", script, true);
            }
             if (e.CommandName == "Eliminar")
            {
                numeroHabitacion = row.Cells[1].Text;
                txtNro.Text = numeroHabitacion;
                txtNro.ReadOnly = true;
                string script = "abrirModal('EliminarHabitacion');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModal", script, true);
            }
        }



        protected void btnAgregarHabitacion_Click(object sender, EventArgs e)
        {
            txtNumero.ReadOnly = false;
            txtNumero.Text = "";
            txtCapacidad.Text = "";
            ddlEstado.SelectedValue = "";
            btnaceptar.Visible = true;
            btnEditar.Visible = false;
            tituloAgregar.Style["display"] = "block";
            tituloEditar.Style["display"] = "none";
            string script = "abrirModal('formularioModalAgregarHabitacion');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModal", script, true);
        }

    }
}
