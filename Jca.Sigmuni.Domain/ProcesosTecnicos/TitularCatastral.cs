using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class TitularCatastral
    {
        public int IdTitularCatastral { get; set; }
        public int? IdPersona { get; set; }
        public int? IdDomicilio { get; set; }
        public int? IdCaracteristicaTitularidad { get; set; }
        public int? IdCondicionPer { get; set; }
        public string? CodContribuyente { get; set; }
        public string? Asociacion { get; set; }
        public int? IdFicha { get; set; }
        public int? NumTitularidad { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual Persona Persona { get; set; }
        public virtual Ficha Ficha { get; set; }
        public virtual CaracteristicaTitularidad CaracteristicaTitularidad { get; set; }
        public virtual CondicionPer CondicionPer { get; set; }

        public virtual ICollection<Dependiente> Dependientes { get; set; }
    }
}
