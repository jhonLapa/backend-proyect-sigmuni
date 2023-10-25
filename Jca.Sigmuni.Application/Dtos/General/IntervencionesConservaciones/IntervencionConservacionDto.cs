namespace Jca.Sigmuni.Application.Dtos.General.IntervencionesConservaciones
{
    public class IntervencionConservacionDto
    {
        public int IdIntervencionConservacion { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        
        public bool? Estado { get; set; } = true;
    }
}
