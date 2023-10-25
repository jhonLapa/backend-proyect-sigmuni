using Jca.Sigmuni.Application.Dtos.Admins.Area;
using Jca.Sigmuni.Application.Dtos.Admins.Cargos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.Admins.AreaCargos
{
    public class AreaCargoDto
    {
        public int Id { get; set; }
        public bool? Estado { get; set; }
        public DateTime FechaRegistro { get; set; } 
        public string? EstadoNombre { get; set; }
        public int? IdCargo { get; set; }
        public int? IdArea { get; set; }

        public AreaDto Area { get; set; }
        public CargoDto Cargo { get; set; }

    }
}
