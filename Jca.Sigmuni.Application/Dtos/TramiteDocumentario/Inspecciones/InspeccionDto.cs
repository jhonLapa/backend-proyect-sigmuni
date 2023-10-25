using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Inspectors;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Solicitudes;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TurnoInspeccions;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Inspecciones
{
    public class InspeccionDto
    {
        public int Id { get; set; }
        public DateTime? FechaAsignacion { get; set; }
        public DateTime? Fecha { get; set; }
        //public string HoraInicio { get; set; }
        //public string HoraFin { get; set; }
        public DateTime? FechaCulminacion { get; set; }
        public int? IdMotivo { get; set; }
        public int IdSolicitud { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }
        public string EstadoNombre { get; set; }
        public int? IdTurno { get; set; }
        public int? IdInspector { get; set; }
        public int? Flag { get; set; }
        public int? IdUsuario { get; set; }
        public string TipoInspector { get; set; }
        public int TipoInspeccion { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }

        //public virtual MotivoDto Motivo { get; set; }
        public virtual SolicitudDto Solicitud { get; set; }
        public virtual TurnoInspeccionDto TurnoInspeccion { get; set; }
        public virtual InspectorDto Inspector { get; set; }
    }
}
