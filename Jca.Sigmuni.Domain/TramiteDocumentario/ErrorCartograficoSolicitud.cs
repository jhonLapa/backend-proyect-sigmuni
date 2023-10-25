using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class ErrorCartograficoSolicitud
    {
        public int Id { get; set; }
        public int IdSolicitud { get; set; }
        public int NroRevision { get; set; }
        public int Conformidad { get; set; }
        public string Observacion { get; set; }
        public int? flag { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        public virtual Solicitud Solicitud { get; set; }
    }
}
