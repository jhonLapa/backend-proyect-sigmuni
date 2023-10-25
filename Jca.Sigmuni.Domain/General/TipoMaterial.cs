using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Domain.General
{
    public class TipoMaterial
    {
        public int IdTipoMaterial { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual ICollection<MonumentoPrehispanico> MonumentoPreinspanico { get; set; }
    }
}
