using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class DerivarSolicitud
    {
        public int Id { get; set; }
        public int IdTramiteSolicitud { get; set; }
        public int IdRemitente { get; set; }
        public string Descripcion { get; set; }
        public string Duracion { get; set; }
        public DateTime FechaEnvio { get; set; }
        public int? IdDocumento { get; set; }
        public int IdArea { get; set; }
        public int IdDestinatario { get; set; }
        public string Observacion { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }

        public virtual TramiteSolicitud? TramiteSolicitud { get; set; }
        public virtual Documento? Documento { get; set; }
        public virtual Usuario? Remitente { get; set; }
        public virtual Usuario? Destinatario { get; set; }

    }
}
