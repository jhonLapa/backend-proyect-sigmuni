using Jca.Sigmuni.Application.Dtos.General.AreaTratamientos;
using Jca.Sigmuni.Application.Dtos.General.ClasesZonificaciones;
using Jca.Sigmuni.Application.Dtos.General.Ubigeos;
using Jca.Sigmuni.Application.Services.Vias.LoteZonificacionParametros;

namespace Jca.Sigmuni.Application.Dtos.Zonificaciones.ZonificacionesParametros
{
    public class ZonificacionParametroDto
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? AmbitoPlano { get; set; }
        public string? Fuente { get; set; }
        public string? Resolucion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string? Editor { get; set; }
        public string? Plano { get; set; }
        public string? Nota { get; set; }
        public string? Observacion { get; set; }
        public DateTime? FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public int? IdClaseZonificacion { get; set; }
        public string? CodigoUbigeo { get; set; }
        public int? IdAreaTratamiento { get; set; }
        public int? IdUsuario { get; set; }
        public string? Ip { get; set; }
        public string? IdZonificacionCarto { get; set; }

        //public virtual ParametroUrbanistico ParametroUrbanistico { get; set; }
         public virtual ClaseZonificacionDto? ClaseZonificacion { get; set; }
        public virtual UbigeoDto? Ubigeo { get; set; }
         public virtual AreaTratamientoDto? AreaTratamiento { get; set; }

        public virtual ICollection<LoteZonificacionParametroDto>? LoteZonificacionParametros { get; set; }
    }
}
