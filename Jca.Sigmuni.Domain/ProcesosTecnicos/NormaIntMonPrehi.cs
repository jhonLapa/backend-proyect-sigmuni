using Jca.Sigmuni.Domain.CompendioNormas;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class NormaIntMonPrehi
    {
        public int IdNormaIntMonPrehi { get; set; }
        public string? NumPlano { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdMonumentoPre { get; set; }
        public int? IdNormaInteres { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual MonumentoPrehispanico? MonumentoPrehispanico { get; set; }
        public virtual NormaInteres? NormaInteres { get; set; }
    }
}
