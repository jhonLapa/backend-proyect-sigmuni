namespace Jca.Sigmuni.Application.Dtos.General.Observaciones
{
    public class ObservacionDto
    {
        public int IdObservacion { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        
        public bool? Estado { get; set; } = true;
    }
}
