using Jca.Sigmuni.Application.Dtos.General.AfectacionesAntropicas;
using Jca.Sigmuni.Application.Dtos.General.AfectacionesNaturales;
using Jca.Sigmuni.Application.Dtos.General.CategoriaInmuebles;
using Jca.Sigmuni.Application.Dtos.General.FiliacionesCronologicas;
using Jca.Sigmuni.Application.Dtos.General.IntervencionesConservaciones;
using Jca.Sigmuni.Application.Dtos.General.Observaciones;
using Jca.Sigmuni.Application.Dtos.General.TipoArquitecturas;
using Jca.Sigmuni.Application.Dtos.General.TipoMateriales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UnidadMedidas;
using System.Text.Json.Serialization;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.MonumentosPrehispanicos
{
    public class MonumentoPrehispanicoDto
    {
        public int IdMonumentoPrehispanico { get; set; }
        public CategoriaInmuebleDto? CategoriaInmueble { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public decimal? Area { get; set; }
        public UnidadMedidaDto? UnidadMedida { get; set; }
        public decimal? Perimetro { get; set; }
        public FiliacionCronologicaDto? FiliacionCronologica { get; set; }
        public string? PresenciaArquitectura { get; set; }
        public TipoArquitecturaDto? TipoArquitectura { get; set; }
        public TipoMaterialDto? TipoMaterial { get; set; }
        public string? OtroTipoMaterial { get; set; }
        public AfectacionNaturalDto? AfectacionNatural { get; set; }
        public string? OtroAfectacionNatural { get; set; }
        public AfectacionAntropicaDto? AfectacionAntropica { get; set; }
        public string? OtroAfectacionAntropica { get; set; }
        public IntervencionConservacionDto? IntervencionConservacion { get; set; }
        public ObservacionDto? Observacion { get; set; }
        public string? ObservacionOtros { get; set; }
        public PresenciaArquitecturaDto? PresenciaAr { get; set; }


        public int? IdFichaBienCultural { get; set; }
    }
}
