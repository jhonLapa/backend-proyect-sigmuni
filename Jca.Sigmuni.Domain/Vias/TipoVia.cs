using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Domain.Vias
{
    public class TipoVia
    {
        public int IdTipoVia { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public virtual ICollection<Via> Vias { get; set; }
        public virtual ICollection<Domicilio> Domicilios{ get; set; }

    }
}
