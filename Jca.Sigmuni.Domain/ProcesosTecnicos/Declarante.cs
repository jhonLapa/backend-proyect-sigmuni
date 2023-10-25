using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class Declarante
    {
        public int IdDeclarante { get; set; }
        public int? IdPersona { get; set; }
        public int? IdCondicionPer { get; set; }
        public int? IdFicha { get; set; }
        public string? Firma { get; set; }
        public bool? TieneFirma { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Persona? Persona { get; set; }
        public virtual CondicionPer? CondicionPer { get; set; }
        public virtual Ficha? Ficha { get; set; }
    }
}
