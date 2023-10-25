using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class AutorizacionMunicipal
    {
        public int IdAutMunicipal { get; set; }
        public int? IdGiroAutorizado { get; set; }
        public int? IdActividadVerificada { get; set; }
        public int IdFicha { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual Ficha Ficha { get; set; }
        public virtual GiroAutorizado GiroAutorizado { get; set; }
        public virtual ActividadVerificada ActividadVerificada { get; set; }
    }
}
