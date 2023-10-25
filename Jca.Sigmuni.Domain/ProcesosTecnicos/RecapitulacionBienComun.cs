using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class RecapitulacionBienComun
    {
        public int Id { get; set; }
        public string? Numero { get; set; }
        public string? Edificacion { get; set; }
        public string? Entrada { get; set; }
        public string? Piso { get; set; }
        public string? Unidad { get; set; }
        public decimal? Porcentaje { get; set; }
        public decimal? LegalTerreno { get; set; }
        public decimal? LegalConstruccion { get; set; }
        public decimal? FisicoTerreno { get; set; }
        public decimal? FisicoConstruccion { get; set; }
        public decimal? Atc { get; set; }
        public decimal? Acc { get; set; }
        public decimal? Aoic { get; set; }
        public int? IdFicha { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual Ficha? Ficha { get; set; }
    }
}
