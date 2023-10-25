using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Domain.General
{
    public class TipoArquitectura
    {
        public int IdTipoArquitectura { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string? Grupo { get; set; }

        public virtual ICollection<MonumentoPrehispanico> MonumentoPreinspanico { get; set; }
        public virtual ICollection<MonumentoColonial> MonumentoColonial { get; set; }
    }
}
