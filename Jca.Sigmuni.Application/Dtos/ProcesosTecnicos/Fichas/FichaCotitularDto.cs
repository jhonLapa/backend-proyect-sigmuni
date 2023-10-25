using Jca.Sigmuni.Application.Dtos.General.Supervisores;
using Jca.Sigmuni.Application.Dtos.General.TblCodigos;
using Jca.Sigmuni.Application.Dtos.General.TecnicosCatastrales;
using Jca.Sigmuni.Application.Dtos.General.UnidadesCatastrales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CotitularesCatastrales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Declarantes;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.InfoComplementarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas
{
    public class FichaCotitularDto
    {
        public FichaDto? Ficha { get; set; }


        public UnidadCatastralDto? UnidadCatastral { get; set; }
        public TblCodigoCatastralDto? CodigoCatastral { get; set; }

        public TblCodigoCatastralRefDto? CodigoCatastralRef { get; set; }

        public List<CotitularCatastralDto>? Cotitulares { get; set; }

        public InfoComplementarioDto? InfoComplementario { get; set; }

        public DeclarantePersonaDto? DeclaranteInfo { get; set; }

        public SupervisorPersonaDto? SupervisorInfo { get; set; }

        public TecnicoCatastralPersonaDto? TecnicoInfo { get; set; }
    }
}
