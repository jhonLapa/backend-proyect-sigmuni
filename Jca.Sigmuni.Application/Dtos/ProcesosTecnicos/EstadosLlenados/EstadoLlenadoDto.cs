namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EstadosLlenados
{
    public class EstadoLlenadoDto
    {
        public int IdEstadoLlenado { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
    }
}
