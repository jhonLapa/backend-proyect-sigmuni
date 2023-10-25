using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class EvaluacionPredioCatastral
    {
        public int Id { get; set; }
        public bool? PredioCatastralOmiso { get; set; }
        public bool? PredioCatastralSubEvaluado { get; set; }
        public bool? PredioCatastralSobreEvaluado { get; set; }
        public bool? PredioCatastralConforme { get; set; }
        public int? IdFicha { get; set; }

        public virtual Ficha Ficha { get; set; }
    }
}
