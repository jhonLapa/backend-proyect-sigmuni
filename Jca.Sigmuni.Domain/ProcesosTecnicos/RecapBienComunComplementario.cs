using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class RecapBienComunComplementario
    {
        public int Id { get; set; }
        public string? AnchoPasaje { get; set; }
        public string? Distancia { get; set; }
        public int IdFicha { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public int Estado { get; set; }

        public virtual Ficha Ficha { get; set; }
    }
}
