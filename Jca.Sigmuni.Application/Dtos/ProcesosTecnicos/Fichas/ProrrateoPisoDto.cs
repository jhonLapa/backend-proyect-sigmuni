using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas
{
    public class ProrrateoPisoDto
    {
        public decimal? AreaTerrenoOcupadaVerificadaPiso { get; set; }

        public decimal? BcGeneralLlegalPiso { get; set; }
        public decimal? BcLlegalTerrenoPiso { get; set; }
        public decimal? BcLlegalConstruccionPiso { get; set; }
        public decimal? BcFisicoTerrenoPiso { get; set; }
        public decimal? BcFisicoContruccionPiso { get; set; }
        public decimal? ATCPiso { get; set; }
        public decimal? ACCPiso { get; set; }
        public decimal? AOICPiso { get; set; }

        public string? Piso { get; set; }

        //Prorrateo
        public string Ambito { get; set; }
        public decimal? AreaTerrenoVerificadaPiso { get; set; }
        public decimal? AreaTechadaVerificadaPiso { get; set; }
        public decimal? ObrasComplementariasPiso { get; set; }
        public string CodPCAPiso { get; set; }
    }
}
