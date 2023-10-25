using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class RecapitulacionEdificio
    {
        public int Id { get; set; }
        public string? Edificio { get; set; }
        public decimal? TotalPorcentaje { get; set; }
        public decimal? TotalAtc { get; set; }
        public decimal? TotalAcc { get; set; }
        public decimal? TotalAoic { get; set; }
        public int IdFicha { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual Ficha Ficha { get; set; }
    }
}
