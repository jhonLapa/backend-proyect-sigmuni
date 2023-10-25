namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class RegistroLegal
    {
        public int IdRegistroLegal { get; set; }
        public string? Notaria { get; set; }
        public string? Kardex { get; set; }
        public DateTime? FechaEscritura { get; set; }
        public int? IdFicha { get; set; }
        public int? IdTipoDocNotarial { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual Ficha Ficha { get; set; }
        public virtual TipoDocNotarial TipoDocNotarial { get; set; }
    }
}
