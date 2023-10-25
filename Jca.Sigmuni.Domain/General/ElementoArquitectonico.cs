using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Domain.General
{
    public class ElementoArquitectonico
    {
        public int IdElementoArquitectonico { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual ICollection<MonumentoColonial> MonumentoColonial { get; set; }
    }
}
