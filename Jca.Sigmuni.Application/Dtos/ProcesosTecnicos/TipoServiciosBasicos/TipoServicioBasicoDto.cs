namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoServiciosBasicos
{
    public class TipoServicioBasicoDto
    {
        public int IdTipoServicioBasico { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public string? Grupo { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
    }
}
