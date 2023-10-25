using Jca.Sigmuni.Application.Dtos.General.UnidadesCatastrales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas
{
    internal class RecapitulacionDeBienesComunesDto
    {
        public UnidadCatastralDto UnidadCatastral { get; set; }
        public decimal? AreaTerrenoOcupadaVerificada { get; set; }
        public int idFichaIndividual { get; set; }
        public decimal? BcGeneralLlegal { get; set; }
        public decimal? BcLlegalTerreno { get; set; }
        public decimal? BcLlegalConstruccion { get; set; }
        public decimal? BcFisicoTerreno { get; set; }
        public decimal? BcFisicoContruccion { get; set; }
        public decimal? ATC { get; set; }
        public decimal? ACC { get; set; }
        public decimal? AOIC { get; set; }

        //Prorrateo
        public string Ambito { get; set; }
        public decimal? AreaTerrenoVerificada { get; set; }
        public decimal? AreaTechadaVerificada { get; set; }
        public decimal? ObrasComplementarias { get; set; }
        public string CodPCA { get; set; }
        public int AreaTotal { get; set; }
        public List<ProrrateoPisoDto> pisoProrrateo { get; set; }
    }
}
