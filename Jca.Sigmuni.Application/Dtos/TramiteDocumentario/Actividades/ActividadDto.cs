using Jca.Sigmuni.Application.Dtos.Admins.Area;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.AcccionesGenerar;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Resultados;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoActividades;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Actividades
{
    public class ActividadDto
    {
        public int Id { get; set; }
        public int? NumeroActividad { get; set; }
        public int? NumeroActividadAnterior { get; set; }
        public int? NumeroActividadSiguiente { get; set; }
        public string? Descripcion { get; set; }
        public int? PlazoAtencion { get; set; }
        public int? NotificacionCorreo { get; set; }
        public int? Flag { get; set; }
        public bool? Estado { get; set; } = true;
        public int? IdTipoActividad { get; set; }
        public int? IdProcedimiento { get; set; }
        public int? IdAccionGenerar { get; set; }
        public long? IdAreaCargo { get; set; }
        public string UltimoPaso { get; set; }
        public string Observacion { get; set; }
        public int? IdResultado { get; set; }
        public int? IdSolicitud { get; set; }
        public int? IdResultadoII { get; set; }
        public int? IdArea { get; set; }


        public TipoActividadDto? TipoActividad { get; set; }
        public AccionGenerarDto? AccionGenerar { get; set; }
        public AreaDto? Area { get; set; }
        public ResultadoDto? Resultado { get; set; }
        public ResultadoDto? Resultado2 { get; set; }
        public TramiteSolicituds.TramiteSolicitudDto? TramiteSolicitud { get; set; }
    }
}
