namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoDeclaratorias
{
    public class TipoDeclaratoriaDto
    {
        public int? Id { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
    }
}
