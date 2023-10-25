using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Domain.Zonificaciones
{
    public class ZonificacionParametro
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
        public virtual ClaseZonificacion? ClaseZonificacion { get; set; }
        public virtual Ubigeo? Ubigeo { get; set; }
        public virtual AreaTratamiento? AreaTratamiento { get; set; }

        public virtual ICollection<LoteZonificacionParametro> LoteZonificacionParametros { get; set; }
    }
}
