namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EdificacionesIndustriales
{
    public class EdificacionIndustrialDto
    {
        public int IdEdificacionIndustrial { get; set; }
        public string? Codigo { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
    }
}
