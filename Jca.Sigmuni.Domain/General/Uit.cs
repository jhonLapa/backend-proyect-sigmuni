using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.General
{
    public class Uit
    {
        public int Id { get; set; }
        public double Monto { get; set; }
        public int? Porcentaje { get; set; }
        public int AnioUit { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
    }
}
