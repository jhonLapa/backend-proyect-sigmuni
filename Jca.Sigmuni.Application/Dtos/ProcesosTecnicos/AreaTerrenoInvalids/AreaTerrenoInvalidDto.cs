using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.AreaTerrenoInvalids
{
    public class AreaTerrenoInvalidDto
    {
        public int IdEvaluacion { get; set; }
        public int? LoteColindante { get; set; }
        public int? JardinAislamiento { get; set; }
        public int? AreaPublica { get; set; }
        public int? AreaIntangible { get; set; }
        public int? IdFicha { get; set; }

        public virtual FichaDto? Ficha { get; set; }
    }
}
