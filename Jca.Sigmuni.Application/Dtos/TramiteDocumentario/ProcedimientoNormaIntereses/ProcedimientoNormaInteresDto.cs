using Jca.Sigmuni.Domain.CompendioNormas;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.ProcedimientoNormaIntereses
{
    public class ProcedimientoNormaInteresDto
    {
        public int Id { get; set; }
        public int? IdProcedimiento { get; set; }
        public virtual Procedimiento? Procedimiento { get; set; }
        public int? IdNormaInteres { get; set; }
        public virtual NormaInteres? NormaInteres { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; } = true;
    }
}
