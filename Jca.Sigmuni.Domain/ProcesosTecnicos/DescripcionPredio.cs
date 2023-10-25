namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class DescripcionPredio
    {
        public int IdDescripcionPredio { get; set; }
        public string? Estructuracion { get; set; }
        public string? Zonificacion { get; set; }
        public decimal? AreaTitulo { get; set; }
        public decimal? AreaLibre { get; set; }
        public decimal? AreaVerificada { get; set; }
        public decimal? AreaDeclarada { get; set; }
        public int? IdClasificacionPredio { get; set; }
        public int? IdUsoPredio { get; set; }
        public int? IdPredioCatastralEn { get; set; }
        public int? IdFicha { get; set; }
        public string? ClasfDescOtros { get; set; }
        public string? PredioCatOtros { get; set; }
        public string? UsoPredioOtros { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual ClasificacionPredio ClasificacionPredio { get; set; }
        public virtual UsoPredio UsoPredio { get; set; }
        public virtual PredioCatastralEn PredioCatastralEn { get; set; }
        public virtual LinderoPredio LinderoPredio { get; set; }
        public virtual Ficha Ficha { get; set; }
    }
}
