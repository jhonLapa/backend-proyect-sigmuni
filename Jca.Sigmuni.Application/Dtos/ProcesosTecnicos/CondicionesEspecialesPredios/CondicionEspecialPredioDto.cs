using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesEspecialesPredios
{
    public class CondicionEspecialPredioDto
    {
        public int IdCondicionEspecialPredio { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
    }
}
