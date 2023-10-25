using Jca.Sigmuni.Domain.PadronNumeraciones.Numeraciones;
using Jca.Sigmuni.Domain.Zonificaciones;

namespace Jca.Sigmuni.Domain.General
{
    public class AreaTratamiento //: ModelBase<int>
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string? NormaAtn { get; set; }

        public virtual ICollection<ZonificacionParametro>? ZonificacionParametros { get; set; }
        public virtual ICollection<Numeracion>? Numeraciones { get; set; }
    }
}
