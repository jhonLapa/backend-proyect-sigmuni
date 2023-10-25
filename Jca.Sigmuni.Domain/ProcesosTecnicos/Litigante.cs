using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class Litigante
    {
        public int IdLitigante { get; set; }
        public string? CodigoContribuyente { get; set; }
        public int? IdPersona { get; set; }
        public int? IdFicha { get; set; }
        public string? CondLitigante { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual Persona Persona { get; set; }
        public virtual Ficha Ficha { get; set; }

        public virtual ICollection<Dependiente> Dependientes { get; set; }
    }
}
