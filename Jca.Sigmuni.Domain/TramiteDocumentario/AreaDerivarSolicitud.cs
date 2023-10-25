using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class AreaDerivarSolicitud
    {
        public int Id { get; set; }
        public int IdDerivarSolicitud { get; set; }
        public int IdArea { get; set; }
        public int Flag { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }

    }
}
