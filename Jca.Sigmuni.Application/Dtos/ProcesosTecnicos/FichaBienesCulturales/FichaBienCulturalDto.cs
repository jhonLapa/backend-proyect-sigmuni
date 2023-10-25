namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaBienesCulturales
{
    public class FichaBienCulturalDto
    {
        public int IdFichaBienCultural { get; set; }
        public string? CUIDistrito { get; set; }
        public string? CUISector { get; set; }
        public string? CUIManzana { get; set; }
        public string? CUILote { get; set; }
        public string? CUISubLote { get; set; }

        public string? CRCZona { get; set; }
        public string? CRCCoordenadaEsta { get; set; }
        public string? CRCCoordenadaNorte { get; set; }
        public string? CRCUnidadCatastral { get; set; }

        
        public int? IdFicha { get; set; }
    }
}
