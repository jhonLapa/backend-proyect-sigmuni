namespace Jca.Sigmuni.Domain.Incidencias
{
    public class TipoIncidencia
    {
        public int IdTipoIncidencia { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => Estado != null && Estado == true ? "Activo" : "Inactivo"; }
        public virtual ICollection<Incidencia> Incidencia { get; set; }
    }
}
