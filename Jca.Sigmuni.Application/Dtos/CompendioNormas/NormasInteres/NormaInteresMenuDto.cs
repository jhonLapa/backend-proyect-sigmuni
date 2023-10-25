using Jca.Sigmuni.Application.Dtos.Admins.Area;
using Jca.Sigmuni.Application.Dtos.Admins.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.CompendioNormas.NormasInteres
{
    public class NormaInteresMenuDto
    {
        public int IdNormaInteresMenu { get; set; }
        public int IdMenu { get; set; }
        public int IdNormaInteres { get; set; }
        public DateTime? FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; }
        public MenuDto Menu { get; set; }
    }
}
