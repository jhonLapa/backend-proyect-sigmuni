namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoFichas
{
    public class TipoFichaDto
    {
        public int IdTipoFicha { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
    }
}
