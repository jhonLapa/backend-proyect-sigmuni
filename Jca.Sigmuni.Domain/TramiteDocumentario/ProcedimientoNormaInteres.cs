using Jca.Sigmuni.Domain.CompendioNormas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class ProcedimientoNormaInteres
    {
        public int Id { get; set; }
        public int? IdProcedimiento { get; set; }
        public virtual Procedimiento? Procedimiento { get; set; }
        public int? IdNormaInteres { get; set; }
        public virtual NormaInteres? NormaInteres { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; } = true;

        public ProcedimientoNormaInteres()
        {
            FechaRegistro = DateTime.UtcNow;
        }
    }
}
