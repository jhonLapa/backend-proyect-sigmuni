using Jca.Sigmuni.Domain.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.CompendioNormas
{
    public class NormaInteresMenu
    {
        public int IdNormaInteresMenu { get; set; }
        public int IdMenu { get; set; }
        public int IdNormaInteres { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public virtual Menu Menu { get; set; }

    }
}
