namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UsosPredios
{
    public class UsoPredioDto
    {
        public int IdUsoPredio { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
    }
}
