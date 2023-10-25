namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoMantenimientos
{
    public class TipoMantenimientoDto
    {
        public int IdTipoMantenimiento { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
    }
}
