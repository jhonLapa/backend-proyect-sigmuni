namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ucas
{
    public class UcaDto
    {
        public int IdUca { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
    }
}
