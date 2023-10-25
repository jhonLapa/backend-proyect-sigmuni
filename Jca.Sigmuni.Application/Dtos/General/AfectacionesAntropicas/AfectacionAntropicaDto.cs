namespace Jca.Sigmuni.Application.Dtos.General.AfectacionesAntropicas
{
    public class AfectacionAntropicaDto
    {
        public int IdAfectacionAntropica { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        
        public bool? Estado { get; set; } = true;
    }
}
