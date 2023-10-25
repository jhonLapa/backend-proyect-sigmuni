namespace Jca.Sigmuni.Application.Dtos.General.Edificaciones.Edificaciones
{
    public class EdificacionDto
    {
        public int Id { get; set; }

        
        public string? Nombre { get; set; }

        
        public string? Manzana { get; set; }

        
        public string? NumLote { get; set; }

        
        public string? LoteUrbano { get; set; }

        
        public string? SubLote { get; set; }


       // public TipoEdificacionDto TipoEdificacion { get; set; }

       // public TipoAgrupacionDto TipoAgrupacion { get; set; }
        public bool Estado { get; set; }
    }
}
