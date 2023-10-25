using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class ActividadTipoDocumento
    {
        public int Id { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        public int IdActividad { get; set; }
        public int IdTipoDocumento { get; set; }
        public int? IdDocumento { get; set; }

        public virtual Actividad Actividad { get; set; }
        public virtual TipoDocumentoPresentado TipoDocumento { get; set; }
    }
}
