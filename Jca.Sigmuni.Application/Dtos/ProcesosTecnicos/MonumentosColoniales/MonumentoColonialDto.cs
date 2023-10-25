using Jca.Sigmuni.Application.Dtos.General.ElementosArquitectonicos;
using Jca.Sigmuni.Application.Dtos.General.EstadosAcabados;
using Jca.Sigmuni.Application.Dtos.General.FiliacionesEstilisticas;
using Jca.Sigmuni.Application.Dtos.General.IntervencionInmuebles;
using Jca.Sigmuni.Application.Dtos.General.Observaciones;
using Jca.Sigmuni.Application.Dtos.General.TiemposConstrucciones;
using Jca.Sigmuni.Application.Dtos.General.TipoArquitecturas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UsosPredios;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.MonumentosColoniales
{
    public class MonumentoColonialDto
    {
        public int IdMonumentoColonial { get; set; }
        public string? PatrimonioCultural { get; set; }
        public string? Denominacion { get; set; }
        public TipoArquitecturaDto? TipoArquitectura { get; set; }
        public UsoPredioDto? UsoPredio { get; set; }
        public UsoPredioDto? UsoOrginalPredio { get; set; }
        public string? NumeroPisoCifra { get; set; }
        public string? NumeroPisoLiteral { get; set; }
        public TiempoConstruccionDto? TiempoConstruccion { get; set; }
        public string? FechaConstruccion { get; set; }
        public decimal? AreaTerrenoTitulo { get; set; }
        public decimal? AreaTechadaVerificada { get; set; }
        public decimal? AreaLibre { get; set; }
        public ElementoArquitectonicoDto? ElementoArquitectonico { get; set; }
        public string? OtroElementoArquitectonico { get; set; }
        public string? DescripcionFachada { get; set; }
        public string? DescripcionInterior { get; set; }
        public FiliacionEstilisticaDto? FiliacionEstilistica { get; set; }
        public string? OtroFiliacionEstilistica { get; set; }
        public EstadoAcabadoDto? EstadoCimiento { get; set; }
        public EstadoAcabadoDto? EstadoMuro { get; set; }
        public EstadoAcabadoDto? EstadoPiso { get; set; }
        public EstadoAcabadoDto? EstadoTecho { get; set; }
        public EstadoAcabadoDto? EstadoPilastra { get; set; }
        public EstadoAcabadoDto? EstadoRevestimiento { get; set; }
        public EstadoAcabadoDto? EstadoBalcon { get; set; }
        public EstadoAcabadoDto? EstadoPuerta { get; set; }
        public EstadoAcabadoDto? EstadoVentana { get; set; }
        public EstadoAcabadoDto? EstadoReja { get; set; }
        public EstadoAcabadoDto? EstadoOtro { get; set; }
        public EstadoAcabadoDto? EstadoLlenado { get; set; }
        public string? OtroEstadoAcabado { get; set; }
        public IntervencionInmuebleDto? IntervencionInmueble { get; set; }
        public string? ReseniaHistorica { get; set; }
        public ObservacionDto? Observacion { get; set; }
        public string? ObservacionOtros { get; set; }
       
        public int IdFichaBienCultural { get; set; }
    }
}
