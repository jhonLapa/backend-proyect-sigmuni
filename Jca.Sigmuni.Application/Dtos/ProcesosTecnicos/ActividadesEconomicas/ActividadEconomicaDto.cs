using Jca.Sigmuni.Application.Dtos.General.RepresentantesConductores;
using Jca.Sigmuni.Application.Dtos.General.Supervisores;
using Jca.Sigmuni.Application.Dtos.General.TblCodigos;
using Jca.Sigmuni.Application.Dtos.General.TecnicosCatastrales;
using Jca.Sigmuni.Application.Dtos.General.UnidadesCatastrales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.AreaActividadesEconomicas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.AutorizacionesAnuncios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.AutorizacionesMunicipales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Conductores;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Declarantes;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.DomicilioConductores;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.InfoComplementarios;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ActividadesEconomicas
{
    public class ActividadEconomicaDto
    {
        
        public FichaDto? Ficha { get; set; }
        public UnidadCatastralDto? UnidadCatastral { get; set; }
        public TblCodigoCatastralDto? CodigoCatastral { get; set; }
        public TblCodigoCatastralRefDto? CodigoCatastralRef { get; set; }
        public ConductorDto? ConductorPersona { get; set; }
        public RepresentanteConductorDto? Representante { get; set; }
        public DomicilioConductorDto? DomicilioConductor { get; set; }
        public List<AutorizacionMunicipalDto>? AutorizacionMunicipal { get; set; }
        public AreaActividadEconomicaDto? AreaActEconomica { get; set; }
        public List<AutorizacionAnuncioDto>? AutorizacionAnuncio { get; set; }
        public InfoComplementarioDto? InfoComplementaria { get; set; }
        public DeclarantePersonaDto? DeclaranteInfo { get; set; }
        public SupervisorPersonaDto? SupervisorInfo { get; set; }
        public TecnicoCatastralPersonaDto? TecnicoInfo { get; set; }
    }
}
