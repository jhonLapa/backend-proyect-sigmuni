using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class FichaIndividual
    {
        public int IdFichaIndividual { get; set; }
        public string? CodContRentas { get; set; }
        public string? CodPredRentas { get; set; }
        public string? UnidadPredRentas { get; set; }
        public int IdFicha { get; set; }
        public decimal? AreaTechadaLegal { get; set; }
        public decimal? AreaOcupadaLegal { get; set; }
        public decimal? AreaOcupadaVerif { get; set; }
        public decimal? PorcBcGenLegal { get; set; }
        public decimal? PorcBcLegalTerr { get; set; }
        public decimal? PorcBcLegalConst { get; set; }
        public decimal? PorcBcFiscTerr { get; set; }
        public decimal? PorcBcFiscConst { get; set; }
        public int? IdPredioCatastralAn { get; set; }
        public string? AreaHabActEcon { get; set; }
        public int? IdTipoDeclaratoria { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual Ficha Ficha { get; set; }
        public virtual PredioCatastralAn PredioCatastralAn { get; set; }
        public virtual TipoDeclaratoria TipoDeclaratoria { get; set; }
    }
}
