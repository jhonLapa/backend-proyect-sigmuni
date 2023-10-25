using Jca.Sigmuni.Application.Dtos.General.Manzanas;
using Jca.Sigmuni.Application.Dtos.General.Sectores;
using Jca.Sigmuni.Application.Dtos.Vias.TipoVias;
using Jca.Sigmuni.Application.Dtos.Vias.Vias;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Aranceles
{
    public class ArancelDto
    {
        public int IdArancel { get; set; }
        public int? Anio { get; set; }
        public string? CodVia { get; set; }
        public int? IdTipoVia { get; set; }
        public string? CodManzana { get; set; }
        public string? CodSector { get; set; }
        public decimal? Valor { get; set; }
        public bool Estado { get; set; }

        public virtual ManzanaDto? Manzana { get; set; }
        public virtual SectorDto? Sector { get; set; }
        public virtual TipoViaDto? TipoVia { get; set; }
        public virtual ViaDto? Via { get; set; }
    }
}
