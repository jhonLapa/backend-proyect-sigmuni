using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class MonumentoPrehispanico
    {
        public int IdMonumentoPrehispanico { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public decimal? Area { get; set; }
        public decimal? Perimetro { get; set; }
        public string? PresenciaArquitectura { get; set; }
        public int? IdTipoMaterial { get; set; }
        public int? IdFichaBienCultural { get; set; }
        public int? IdUnidadMedida { get; set; }
        public int? IdCategoriaInmueble { get; set; }
        public int? IdFiliacionCronologica { get; set; }
        public int? IdAfectacionNatural { get; set; }
        public int? IdAfectacionAntropica { get; set; }
        public int? IdTipoArquitectura { get; set; }
        public int? IdIntervencionConservacion { get; set; }
        public int? IdObservacion { get; set; }
        public string? OtroTipoMaterial { get; set; }
        public string? OtroAfectacionNatural { get; set; }
        public string? OtroAfectacionAntropica { get; set; }
        public string? ObservacionOtros { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual TipoMaterial? TipoMaterial { get; set; }
        public virtual FichaBienCultural? FichaBienCultural { get; set; }
        public virtual UnidadMedida? UnidadMedida { get; set; }
        public virtual CategoriaInmueble? CategoriaInmueble { get; set; }
        public virtual FiliacionCronologica? FiliacionCronologica { get; set; }
        public virtual AfectacionNatural? AfectacionNatural { get; set; }
        public virtual AfectacionAntropica? AfectacionAntropica { get; set; }
        public virtual TipoArquitectura? TipoArquitectura { get; set; }
        public virtual IntervencionConservacion? IntervencionConservacion { get; set; }
        public virtual Observacion? Observacion { get; set; }

        public virtual ICollection<Sunarp>? Sunarp { get; set; }
        public virtual ICollection<NormaIntMonPrehi>? NormaIntMonPreins { get; set; }
    }
}
