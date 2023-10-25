using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Actividades;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Resultados;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Solicitudes;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TramiteSolicituds
{
    public class TramiteSolicitudDto
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
        public DateTime? FechaRegistro { get; set; }
        public bool? Estado { get; set; }
        public string? EstadoNombre { get; set; }

        public virtual SolicitudDto? Solicitud { get; set; }
        public virtual Documento? Documento { get; set; }
        public virtual ActividadDto? Actividad { get; set; }
        public virtual ResultadoDto? Resultado { get; set; }
    }
}
