namespace Jca.Sigmuni.Application.Dtos.General.IntervencionInmuebles
{
    public class IntervencionInmuebleDto
    {
        public int IdIntervencionInmueble { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        
        public bool? Estado { get; set; } = true;
    }
}
