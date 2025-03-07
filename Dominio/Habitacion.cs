using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominio
{
    public class Habitacion
    {
        public int Numero { get; set; }
        public int Capacidad { get; set; }
        public string Estado { get; set; }
        public bool Activo { get; set; }
        public decimal PrecioBase { get; set; }

        public override string ToString()
        {
            return Numero.ToString();
        }
    }
}