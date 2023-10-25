namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoInspecciones
{
    public class TipoInspeccionDto
    {
        public int IdTipoInspeccion { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
    }
}
