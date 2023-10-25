using Jca.Sigmuni.Domain.CompendioNormas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class Autoridad
    {
        public int IdAutoridad { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        //public virtual ICollection<NormaDiaDetalle> NormaDiaDetalle { get; set; }
        //public virtual ICollection<NormaInteres> NormaInteres { get; set; }
    }
}
