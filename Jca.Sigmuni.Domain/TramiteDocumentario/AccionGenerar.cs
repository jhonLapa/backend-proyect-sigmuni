namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class AccionGenerar
    {
        public int IdAccionGenerar { get; set; }
        public string? Tipo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public virtual ICollection<Actividad> Actividad { get; set; }

    }
}
