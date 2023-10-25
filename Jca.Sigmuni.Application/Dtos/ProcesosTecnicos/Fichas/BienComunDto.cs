using Jca.Sigmuni.Application.Dtos.General.Supervisores;
using Jca.Sigmuni.Application.Dtos.General.TblCodigos;
using Jca.Sigmuni.Application.Dtos.General.TecnicosCatastrales;
using Jca.Sigmuni.Application.Dtos.General.UnidadesCatastrales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Construcciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Declarantes;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.DescripcionPredios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.DocumentoObras;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Edificaciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EvaluacionPredios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaIndividuales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.InfoComplementarios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.OtraInstalaciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Puertas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.RecapBienComunComplementarios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.RecapitulacionBienComunes;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.RecapitulacionEdificios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.RegistroLegales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Resoluciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ServicioBasicos;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Sunarps;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UbicacionPredios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas
{
    public class BienComunDto
    {
        public FichaDto? Ficha { get; set; }

        public UnidadCatastralDto? UnidadCatastral { get; set; }

        public TblCodigoCatastralDto? CodigoCatastral { get; set; }

        public int? idFichaIndividual { get; set; }

        public TblCodigoCatastralRefDto? CodigoCatastralRef { get; set; }

        public UbicacionPredioDto? Ubicacion { get; set; }

        public EdificacionDto? Edificacion { get; set; }

        public List<PuertaDto>? Puertas { get; set; }

        public DescripcionPredioDto? DescripcionPredio { get; set; }

        public EvaluacionPredioDto? EvaluacionPredio { get; set; }

        public ServicioBasicoDto? ServicioBasico { get; set; }

        public List<ConstruccionDto>? Construcciones { get; set; }

        public FichaIndividualDto? IndividualAdicional { get; set; }

        public List<OtraInstalacionDto>? OtraInstalaciones { get; set; }

        public List<RecapitulacionEdificioDto>? RecapEdificios { get; set; }

        public List<RecapitulacionBienComunDto>? RecapBienComunes { get; set; }

        public List<RecapBienComunComplementarioDto>? RecapBienComunComplemetarios { get; set; }

        public List<SunarpDto>? Inscripciones { get; set; }

        public List<RegistroLegalDto>? InfoLegal { get; set; }

        public InfoComplementarioDto? InfoComplementario { get; set; }

        public DeclarantePersonaDto? DeclaranteInfo { get; set; }

        public SupervisorPersonaDto? SupervisorInfo { get; set; }

        public TecnicoCatastralPersonaDto? TecnicoInfo { get; set; }

        public int? CantidadUnidadesAsociadas { get; set; }

        public List<DocumentoObraDto>? DocumentosObra { get; set; }

        public List<ResolucionDto>? Resoluciones { get; set; }
    }
}
