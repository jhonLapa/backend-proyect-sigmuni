namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class Mep
    {
        public int IdMep { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual ICollection<Construccion> Construcciones { get; set; }
        public virtual ICollection<OtraInstalacion> OtraInstalaciones { get; set; }
        public virtual ICollection<Depreciacion> Depreciacion { get; set; }
    }
}
