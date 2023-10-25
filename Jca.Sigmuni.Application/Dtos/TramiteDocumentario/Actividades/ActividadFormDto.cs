using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Actividades
{
    public class ActividadFormDto
    {
        public int? NumeroActividad { get; set; }
        public int? NumeroActividadAnterior { get; set; }
        public int? NumeroActividadSiguiente { get; set; }
        public string? Descripcion { get; set; }
        public int? PlazoAtencion { get; set; }
        public int? NotificacionCorreo { get; set; }
        public int? Flag { get; set; }
        public int? IdTipoActividad { get; set; }
        public int? IdProcedimiento { get; set; }
        public int? IdAccionGenerar { get; set; }
        public long? IdAreaCargo { get; set; }
        public string? UltimoPaso { get; set; }
        public string? Observacion { get; set; }
        public int? IdResultado { get; set; }
        public int? IdSolicitud { get; set; }
        public int? IdResultadoII { get; set; }
        public int? IdArea { get; set; }
    }
}
