using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class TipoNorma
    {
        public int IdTipoNorma { get; set; }
        public string? Codigo { get; set; }
        public float? flag { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        //public virtual ICollection<NormaDia> NormaDia { get; set; }
    }
}
