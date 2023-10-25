using Jca.Sigmuni.Application.Dtos.Admins.Domicilios;
using Jca.Sigmuni.Application.Dtos.General.Dependientes;
using Jca.Sigmuni.Application.Dtos.General.ExoneracionTitulares;
using Jca.Sigmuni.Application.Dtos.General.Supervisores;
using Jca.Sigmuni.Application.Dtos.General.TblCodigos;
using Jca.Sigmuni.Application.Dtos.General.TecnicosCatastrales;
using Jca.Sigmuni.Application.Dtos.General.UnidadesCatastrales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.AreaTerrenoInvalids;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CaracteristicaTitularidades;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Construcciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Declarantes;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.DescripcionPredios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.DocumentoObras;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Edificaciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EvaluacionPredioCatastrales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EvaluacionPredios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ExoneracionPredios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaDocumentos;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaIndividuales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.InfoComplementarios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Litigantes;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ocupantes;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.OtraInstalaciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Puertas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.RegistroLegales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Resoluciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ServicioBasicos;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Sunarps;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TitularCatastrales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UbicacionPredios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.VerificadorCatastrales;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas
{
    public class IndividualDto
    {
        public FichaDto? Ficha { get; set; }

        public UnidadCatastralDto? UnidadCatastral { get; set; }

        public TblCodigoCatastralDto? CodigoCatastral { get; set; }

        public TblCodigoCatastralRefDto? CodigoCatastralRef { get; set; }

        public UbicacionPredioDto? Ubicacion { get; set; }

        public EdificacionDto? Edificacion { get; set; }

        public List<PuertaDto>? Puertas { get; set; }

        public CaracteristicaTitularidadDto? CaracteristicaTitularidad { get; set; }

        public ExoneracionPredioDto? ExoneracionPredio { get; set; }

        public PersonaTitularDto? Titular { get; set; }

        public ExoneracionTitularDto? ExoneracionTitular { get; set; }

        public DomicilioTitularCatastralDto? DomicilioTitular { get; set; }

        public DescripcionPredioDto? DescripcionPredio { get; set; }

        public EvaluacionPredioDto? EvaluacionPredio { get; set; }

        public ServicioBasicoDto? ServicioBasico { get; set; }

        public List<ConstruccionDto>? Construcciones { get; set; }

        public FichaIndividualDto? IndividualAdicional { get; set; }

        public List<OtraInstalacionDto>? OtraInstalaciones { get; set; }

        public List<FichaDocumentoDto>? Documentos { get; set; }

        public List<SunarpDto>? Inscripciones { get; set; }

        public List<RegistroLegalDto>? InfoLegal { get; set; }

        public OcupantePersonaDto? OcupantePersona { get; set; }

        public List<PersonaLitiganteDto>? Litigantes { get; set; }

        public List<ConyugeLitiganteDto>? ConyugesLitigante { get; set; }

        public List<PersonaLitiganteJuridicoDto>? JuridicoLitigantes { get; set; }

        public InfoComplementarioDto? InfoComplementario { get; set; }

        public DeclarantePersonaDto? DeclaranteInfo { get; set; }

        public SupervisorPersonaDto? SupervisorInfo { get; set; }

        public TecnicoCatastralPersonaDto? TecnicoInfo { get; set; }

        public List<DocumentoObraDto>? DocumentosObra { get; set; }

        public List<ResolucionDto>? Resoluciones { get; set; }

        public EvaluacionPredioCatastralDto? EvaluacionPredioCatastral { get; set; }

        public AreaTerrenoInvalidDto? AreaTerrenoInvalid { get; set; }

        public VerificadorCatastralDto? VerificadorCatastral { get; set; }
    }
}
