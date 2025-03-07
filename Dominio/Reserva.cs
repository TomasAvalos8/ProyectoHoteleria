using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Web;
namespace Dominio
{
    public class Reserva
    {

        public int Id { get; set; }
        public int DNI_Huesped { get; set; }
        public string Nombre_Huesped { get; set; }
        public string Telefono { get; set; }
        public int Numero_Habitacion { get; set; }
        public int Capacidad { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaEgreso { get; set; }
        public bool Activo { get; set; }
        public Decimal TotalReserva { get; set; }
    }
}