using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Domain.General
{
    public class TecnicoCatastral
    {
        public int IdTecnicoCatastral { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdPersona { get; set; }
        public int IdFicha { get; set; }
        public string? Firma { get; set; }
        public bool? TieneFirma { get; set; }

        public virtual Persona Persona { get; set; }
        public virtual Ficha Ficha { get; set; }
    }
}
