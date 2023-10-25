namespace Jca.Sigmuni.Application.Dtos.General.TiemposConstrucciones
{
    public class TiempoConstruccionDto
    {
        public int IdTiempoConstruccion { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        
        public bool? Estado { get; set; } = true;
    }
}
