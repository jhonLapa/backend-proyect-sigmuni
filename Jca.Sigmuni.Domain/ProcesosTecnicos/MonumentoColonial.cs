using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class MonumentoColonial
    {
        public int IdMonumentoColonial { get; set; }
        public string? PatrimonioCultural { get; set; }
        public string? Denominacion { get; set; }
        public int? IdFichaBienCultural { get; set; }
        public string? DescripcionFachada { get; set; }
        public string? DescripcionInterior { get; set; }
        public string? ReseniaHistorica { get; set; }
        public int? IdTiempoConstruccion { get; set; }
        public int? IdElementoArquitectonico { get; set; }
        public int? IdFiliacionEstilistica { get; set; }
        public int? IdIntervencionInmueble { get; set; }
        public string? OtroElementoArquitectonico { get; set; }
        public string? OtroFiliacionEstilistica { get; set; }
        public int? IdCimiento { get; set; }
        public int? IdMuro { get; set; }
        public int? IdPiso { get; set; }
        public int? IdTecho { get; set; }
        public int IdPilastra { get; set; }
        public int? IdRevestimiento { get; set; }
        public int? IdBalcon { get; set; }
        public int? IdPuerta { get; set; }
        public int? IdVentana { get; set; }
        public int? IdReja { get; set; }
        public int? IdOtro { get; set; }
        public string? OtroEstadoAcabado { get; set; }
        public int? IdTipoArquitectura { get; set; }
        public int? IdUsoPredio { get; set; }
        public int? IdUsoOrginalPredio { get; set; }
        public string? FechaConstruccion { get; set; }
        public decimal? AreaTerrenoTitulo { get; set; }
        public decimal? AreaTechadaVerificada { get; set; }
        public decimal? AreaLibre { get; set; }
        public int? IdObservacion { get; set; }
        public string? NumeroPisoCifra { get; set; }
        public string? NumeroPisoLiteral { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual FichaBienCultural? FichaBienCultural { get; set; }
        public virtual TipoArquitectura? TipoArquitectura { get; set; }
        public virtual TiempoConstruccion? TiempoConstruccion { get; set; }
        public virtual ElementoArquitectonico? ElementoArquitectonico { get; set; }
        public virtual FiliacionEstilistica? FiliacionEstilistica { get; set; }
        public virtual IntervencionInmueble? IntervencionInmueble { get; set; }
        public virtual UsoPredio? UsoPredio { get; set; }
        public virtual UsoPredio? UsoPredioOrginal { get; set; }
        public virtual EstadoAcabado? EstadoCimiento { get; set; }
        public virtual EstadoAcabado? EstadoMuro { get; set; }
        public virtual EstadoAcabado? EstadoPiso { get; set; }
        public virtual EstadoAcabado? EstadoTecho { get; set; }
        public virtual EstadoAcabado? EstadoPilastra { get; set; }
        public virtual EstadoAcabado? EstadoRevestimiento { get; set; }
        public virtual EstadoAcabado? EstadoBalcon { get; set; }
        public virtual EstadoAcabado? EstadoPuerta { get; set; }
        public virtual EstadoAcabado? EstadoVentana { get; set; }
        public virtual EstadoAcabado? EstadoReja { get; set; }
        public virtual EstadoAcabado? EstadoOtro { get; set; }
        public virtual Observacion? Observacion { get; set; }

        public virtual ICollection<Sunarp>? Sunarp { get; set; }
        public virtual ICollection<NormaIntMonColonial>? NormaIntMonColonial { get; set; }
    }
}
