using Jca.Sigmuni.Application.Dtos.General.Documentos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.ProcedimientoRequisitos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.SolicitudRequisitos
{
    public class SolicitudRequisitoDto
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
        public int? IpAccion { get; set; }

        public int? numero { get; set; }


        public ProcedimientoRequisitoDto? ProcedimientoRequisito { get; set; }
        public DocumentoB64FormDto? DocumentoB64 { get; set; }
        public DocumentoDto? Documento { get; set; }
    }
}
