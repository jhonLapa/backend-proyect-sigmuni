namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesNumeraciones
{
    public class CondicionNumeracionDto
    {
        public int IdCondicionNumeracion { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        
      
        public bool? Estado { get; set; } = true;
    }
}
