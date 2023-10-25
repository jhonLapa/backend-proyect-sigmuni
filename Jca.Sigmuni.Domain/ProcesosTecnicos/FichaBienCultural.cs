namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class FichaBienCultural
    {
        public int IdFichaBienCultural { get; set; }
        public int? IdFicha { get; set; }
        public string? CUIDistrito { get; set; }
        public string? CUISector { get; set; }
        public string? CUIManzana { get; set; }
        public string? CUILote { get; set; }
        public string? CUISubLote { get; set; }
        public string? CRCZona { get; set; }
        public string? CRCCoordenadaEsta { get; set; }
        public string? CRCCoordenadaNorte { get; set; }
        public string? CRCUnidadCatastral { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual Ficha? Ficha { get; set; }

        public virtual ICollection<MonumentoPrehispanico>? MonumentoPreinspanico { get; set; }
        public virtual ICollection<MonumentoColonial>? MonumentoColonial { get; set; }
    }
}
