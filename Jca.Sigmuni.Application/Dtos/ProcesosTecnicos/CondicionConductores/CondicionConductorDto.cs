namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionConductores
{
    public class CondicionConductorDto
    {
        public int IdCondicionConductor { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
    }
}
