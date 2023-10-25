using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class TramiteSolicitud
    {
        public int Id { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaCulminacion { get; set; }
        public string? Observaciones { get; set; }
        public string? Detalle { get; set; }
        public int? Flag { get; set; }
        public int? IdSolicitud { get; set; }
        public int? IdActividad { get; set; }
        public string? Folios { get; set; }
        public int? IdResultado { get; set; }
        public DateTime? FechaCulminacionReal { get; set; }
        public int? CumplimientoActividad { get; set; }
        public int? IdDocumento { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        public virtual Solicitud? Solicitud { get; set; }
        public virtual Documento? Documento { get; set; }
        public virtual Actividad? Actividad { get; set; }
        public virtual Resultado? Resultado { get; set; }
        //public virtual ICollection<DetalleTramite> DetalleTramites { get; set; }
        //public virtual ICollection<ErrorInspeccion> ErrorInspecciones { get; set; }
        public virtual ICollection<DerivarSolicitud>? DerivarSolicitud { get; set; }
    }
}
