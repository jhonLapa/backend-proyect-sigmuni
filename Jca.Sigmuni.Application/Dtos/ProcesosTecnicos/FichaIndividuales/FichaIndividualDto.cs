using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.PredioCatastralesAn;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoDeclaratorias;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaIndividuales
{
    public class FichaIndividualDto
    {
        public int IdFichaIndividual { get; set; }

        //[MaxLength(15, ErrorMessage = "En el campo Código Contribuyente Rentas ingrese como máximo 15 carácteres")]
        public string? CodContRentas { get; set; }

        //[MaxLength(15, ErrorMessage = "En el campo Código Predial Rentas ingrese como máximo 15 carácteres")]
        public string? CodPredRentas { get; set; }

        //[MaxLength(15, ErrorMessage = "En el campo Unidad Predial Rentas ingrese como máximo 15 carácteres")]
        public string? UnidadPredRentas { get; set; }

        public decimal? AreaTechadaLegal { get; set; }
        public decimal? AreaOcupadaLegal { get; set; }
        public decimal? AreaOcupadaVerif { get; set; }
        public decimal? PorcBcGenLegal { get; set; }
        public decimal? PorcBcLegalTerr { get; set; }
        public decimal? PorcBcLegalConst { get; set; }
        public decimal? PorcBcFiscTerr { get; set; }
        public decimal? PorcBcFiscConst { get; set; }
        public string? AreaHabActEcon { get; set; }


        public PredioCatastralAnDto? PredioCatastralAn { get; set; }

        public TipoDeclaratoriaDto? TipoDeclaratoria { get; set; }

        [JsonIgnore]
        //[Required(ErrorMessage = "Id es requerido entidad Ficha Individual")]
        public int IdFicha { get; set; }
    }
}
