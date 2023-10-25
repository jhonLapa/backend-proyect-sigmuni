namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class TipoActividad
    {
        public int IdTipoActividad { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Categoria { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public ICollection<Actividad> Actividad { get; set; }
    }
}
