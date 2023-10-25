using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class SupervisorInsp
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }

        public int? Flag { get; set; }

        public virtual Persona Persona { get; set; }
        public virtual ICollection<Inspector> Inspectores { get; set; }
    }
}
