using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class InfoComplementario
    {
        public int IdInfoComplementario { get; set; }
        public int? NumHabitantes { get; set; }
        public int? NumFamilias { get; set; }
        public string? Observaciones { get; set; }
        public int? IdObservacion { get; set; }
        public int? IdTipoMantenimiento { get; set; }
        public int? IdEstadoLlenado { get; set; }
        public int IdFicha { get; set; }
        public string? NumComunicacion { get; set; }
        public int? IdTipoInspeccion { get; set; }
        public int? IdMotivo { get; set; }
        public int? IdTipoDocumento { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual TipoMantenimiento? TipoMantenimiento { get; set; }
        public virtual EstadoLlenado? EstadoLLenado { get; set; }
        public virtual TipoInspeccion? TipoInspeccion { get; set; }
        public virtual Ficha? Ficha { get; set; }
        public virtual Observacion? Observacion { get; set; }
    }
}
