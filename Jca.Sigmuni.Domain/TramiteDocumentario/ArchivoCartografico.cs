using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class ArchivoCartografico
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int IdDocumento { get; set; }
        public int IdSolicitud { get; set; }
        public int flag { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        public virtual Documento Documento { get; set; }

    }
}
