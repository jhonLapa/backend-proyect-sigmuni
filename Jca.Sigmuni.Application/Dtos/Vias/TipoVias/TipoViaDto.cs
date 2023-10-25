namespace Jca.Sigmuni.Application.Dtos.Vias.TipoVias
{
    public class TipoViaDto
    {
        public int IdTipoVia { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
    }
}
