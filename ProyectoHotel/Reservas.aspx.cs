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



        protected void gvHabitaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            int index = Convert.ToInt32(e.CommandArgument);


            GridViewRow row = gvHabitaciones.Rows[index];


            if (e.CommandName == "Agregar")
            {
                Session["NumeroHabitacion"] = row.Cells[1].Text;
                Session["Capacidad"] = row.Cells[2].Text;
                Session["Estado"] = row.Cells[3].Text;

                Response.Redirect("FormularioReserva.aspx");

            }
            else if (e.CommandName == "Editar")
            {
                numeroHabitacion = row.Cells[1].Text;
                capacidad = row.Cells[2].Text;
                estado = row.Cells[3].Text;
                txtNumero.Text = numeroHabitacion;
                txtNumero.ReadOnly = true;
                txtCapacidad.Text = capacidad;
                txtEstado.Text = estado;
                btnaceptar.Visible = false;
                btnEditar.Visible = true;
                string script = "abrirModal();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModal", script, true);
            }
            else if (e.CommandName == "Eliminar")
            {
                numeroHabitacion = row.Cells[1].Text;
                capacidad = row.Cells[2].Text;
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAgregarHabitacion_Click(object sender, EventArgs e)
        {
            txtNumero.Text = "";
            txtCapacidad.Text = "";
            txtEstado.Text = "";
            btnaceptar.Visible = true;
            btnEditar.Visible =false;
            string script = "abrirModal();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModal", script, true);
        }
    }
}
