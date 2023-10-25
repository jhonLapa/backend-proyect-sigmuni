using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class AreaTerrenoInvalid
    {
        public int IdEvaluacion { get; set; }
        public int? LoteColindante { get; set; }
        public int? JardinAislamiento { get; set; }
        public int? AreaPublica { get; set; }
        public int? AreaIntangible { get; set; }
        public int? IdFicha { get; set; }

        public virtual Ficha? Ficha { get; set; }

    }
}
