using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class ProcedimientoRequisito
    {
        public int Id { get; set; }
        public int? IdProcedimiento { get; set; }
        public int? IdRequisito { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; } = true;
        public virtual Procedimiento? Procedimiento { get; set; }
        public virtual Requisito? Requisito { get; set; }
        public virtual ICollection<SolicitudRequisito>? SolicitudRequisito { get; set; }

        public ProcedimientoRequisito()
        {
            FechaRegistro = DateTime.UtcNow;
        }
    }
}
