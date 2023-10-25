using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Domain.General
{
    public class Observacion
    {
        public int IdObservacion { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual ICollection<MonumentoColonial> MonumentoColonial { get; set; }
        public virtual ICollection<MonumentoPrehispanico> MonumentoPrehispanico { get; set; }
        public virtual ICollection<InfoComplementario> InfoComplementarios { get; set; }
    }
}
