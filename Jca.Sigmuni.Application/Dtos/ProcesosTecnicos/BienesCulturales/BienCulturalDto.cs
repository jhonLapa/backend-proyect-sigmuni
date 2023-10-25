using Jca.Sigmuni.Application.Dtos.General.Dependientes;
using Jca.Sigmuni.Application.Dtos.General.Supervisores;
using Jca.Sigmuni.Application.Dtos.General.TblCodigos;
using Jca.Sigmuni.Application.Dtos.General.TecnicosCatastrales;
using Jca.Sigmuni.Application.Dtos.General.UnidadesCatastrales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CaracteristicaTitularidades;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Declarantes;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaBienesCulturales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.InfoComplementarios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Litigantes;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.MonumentosColoniales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.MonumentosPrehispanicos;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.NormaIntMonColoniales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.NormaIntMonPreins;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Sunarps;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TitularCatastrales;
using System.ComponentModel.DataAnnotations;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.BienesCulturales
{
    public class BienCulturalDto
    {
        
        public FichaDto? Ficha { get; set; }

        
        public UnidadCatastralDto? UnidadCatastral { get; set; }

        
        public TblCodigoCatastralDto? CodigoCatastral { get; set; }

        public TblCodigoCatastralRefDto? CodigoCatastralRef { get; set; }

        public FichaBienCulturalDto? DatoAdicinalFicha { get; set; }

        public MonumentoPrehispanicoDto? MonumentoPrehispanico { get; set; }

        public List<NormaIntMonPrehiDto>? NormaInteresMonPreinspanico { get; set; }

        public List<SunarpDto>? RegistroPrediosMonumentoPre { get; set; }

        public MonumentoColonialDto? InfoMonumentoColonial { get; set; }

        public List<NormaIntMonColonialDto>? NormaInteresMonColonial { get; set; }

        public CaracteristicaTitularidadDto? CaracteristicaTitularidad { get; set; }

        public PersonaTitularDto? Titular { get; set; }

        public List<SunarpDto>? RegistroPrediosMonumentoColonial { get; set; }

        public List<PersonaLitiganteDto>? NaturalLitigante { get; set; }

        public List<ConyugeLitiganteDto>? ConyugesLitigante { get; set; }

        public List<PersonaLitiganteJuridicoDto>? JuridicoLitigante { get; set; }

        public InfoComplementarioDto? InfoComplementaria { get; set; }

        public DeclarantePersonaDto? DeclaranteInfo { get; set; }

        public SupervisorPersonaDto? SupervisorInfo { get; set; }

        public TecnicoCatastralPersonaDto? TecnicoInfo { get; set; }
    }
}
