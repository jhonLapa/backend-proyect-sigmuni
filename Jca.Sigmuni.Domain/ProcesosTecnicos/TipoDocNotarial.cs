namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class TipoDocNotarial
    {
        public int IdTipoDocNotarial { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual ICollection<RegistroLegal> RegistroLegales { get; set; }
    }
}
