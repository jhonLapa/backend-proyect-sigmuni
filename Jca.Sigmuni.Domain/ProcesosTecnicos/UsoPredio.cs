namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class UsoPredio
    {
        public int IdUsoPredio { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual ICollection<DescripcionPredio> DescripcionPredios { get; set; }
        public virtual ICollection<MonumentoColonial> MonumentoColonialUso { get; set; }
        public virtual ICollection<MonumentoColonial> MonumentoColonialUsoOrginal { get; set; }
    }
}
