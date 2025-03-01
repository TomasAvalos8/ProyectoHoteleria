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
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                CargarReservas();
            }
        }
        private void CargarReservas()
        {
            ReservaNegocio negocio = new ReservaNegocio();
            List<Reserva> lista = negocio.Listar();
            dgvReservas.DataSource = lista;
            dgvReservas.DataBind();
        }
    }
}