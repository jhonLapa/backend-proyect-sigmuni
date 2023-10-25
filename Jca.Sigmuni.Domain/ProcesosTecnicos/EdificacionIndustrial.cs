namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class EdificacionIndustrial
    {
        public int IdEdificacionIndustrial { get; set; }
        public string? Codigo { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual ICollection<Construccion> Construcciones { get; set; }
    }
}
