namespace Jca.Sigmuni.Domain.General
{
    public class ExoneracionTitular
    {
        public int IdExoneracionTitular { get; set; }
        public int? IdCondicionEspecialTitular { get; set; }
        public string? NumeroResolucion { get; set; }
        public string? NumeroBoletaPension { get; set; }
        public string? AnioResolucion { get; set; }
        public string? AnioBoletaPension { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public DateTime? FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public int? IdTipoExoneracion { get; set; }
        public int? IdPersona { get; set; }

        public virtual CondicionEspecialTitular? CondicionEspecialTitular { get; set; }
        public virtual Persona? Persona { get; set; }
        public virtual TipoExoneracion? TipoExoneracion { get; set; }
    }
}
