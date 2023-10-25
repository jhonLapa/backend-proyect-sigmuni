namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CategoriaConstrucciones
{
    public class CategoriaConstruccionDto
    {
        public int IdCategoriaConstruccion { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        
        public bool? Estado { get; set; } = true;
    }
}
