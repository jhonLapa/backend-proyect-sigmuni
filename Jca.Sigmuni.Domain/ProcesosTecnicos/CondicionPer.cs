using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class CondicionPer
    {
        public int IdCondicionPer { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual ICollection<Declarante>? Declarantes { get; set; }
        public virtual ICollection<TitularCatastral>? TitularCatastral { get; set; }
        public virtual ICollection<Ocupante>? Ocupantes { get; set; }
        public virtual ICollection<VerificadorCatastral> VerificadorCatastrales { get; set; }
    }
}
