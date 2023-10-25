using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.ArchivoDocumentario
{
    public class Expediente
    {
        public int Id { get; set; }
        public int IdDocumento { get; set; }
        public int IdInfDocumento { get; set; }
        public int Folios { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string? EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        public virtual InfDocumento? InfDocumento { get; set; }
        public virtual Documento? Documento { get; set; }

        public virtual ICollection<Marcador> Marcador { get; set; }

    }
}
