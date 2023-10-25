namespace Jca.Sigmuni.Application.Dtos.General.AfectacionesNaturales
{
    public class AfectacionNaturalDto
    {
        public int IdAfectacionNatural { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        
        public bool? Estado { get; set; } = true;
    }
}
