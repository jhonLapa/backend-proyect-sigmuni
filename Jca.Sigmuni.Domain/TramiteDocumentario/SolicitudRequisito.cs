using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class SolicitudRequisito
    {
        public int Id { get; set; }
        public string? Flag { get; set; }
        public int? IdSolicitud { get; set; }
        public int? IdProcedimientoRequisito { get; set; }
        public int? IdDocumento { get; set; }
        public int? Folios { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; } = true;
        public int? DocumentoObservacion { get; set; }
        public int? IdUsuario { get; set; }
        public string? IpAccion { get; set; }
        public virtual Solicitud? Solicitud { get; set; }
        public virtual ProcedimientoRequisito? ProcedimientoRequisito { get; set; }
        public virtual Documento? Documento { get; set; }

        public SolicitudRequisito()
        {
            FechaRegistro = DateTime.UtcNow;
        }
    }
}
