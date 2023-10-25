using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesPer
{
    public class CondicionPerDto
    {
        public int IdCondicionPer { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }
    }
}
