using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.CompendioNormas
{
    public class NormaDiaDetalle
    {
        public int IdNormaDiaDetalle { get; set; }
        public int IdNormaDia { get; set; }
        public string? Nombre { get; set; }
        public string? Sumilla { get; set; }
        public bool? Estado { get; set; } = true;
        public bool? FlagNotificacion { get; set; } = true;
        public string? Enlace { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;

        public int IdAutoridad { get; set; }
       
        public virtual ICollection<NormaInteres>? NormaInteres { get; set; }

    }
}
