using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.Vias;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class Arancel
    {
        public int IdArancel { get; set; }
        public int? Anio { get; set; }
        public string? IdVia { get; set; }
        public string? IdManzana { get; set; }
        public decimal? Valor { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public virtual Manzana? Manzana { get; set; }
        public virtual Via? Via { get; set; }
    }
}
