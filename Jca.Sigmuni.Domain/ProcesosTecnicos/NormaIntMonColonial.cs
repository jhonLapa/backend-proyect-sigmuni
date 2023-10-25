using Jca.Sigmuni.Domain.CompendioNormas;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class NormaIntMonColonial
    {
        public int IdNormaIntMonColonial { get; set; }
        public string? NumPlano { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdMonumentoColonial { get; set; }
        public int? IdNormaInteres { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual MonumentoColonial? MonumentoColonial { get; set; }
        public virtual NormaInteres? NormaInteres { get; set; }
    }
}
