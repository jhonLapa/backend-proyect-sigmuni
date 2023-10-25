using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class TipoDocumentoPresentado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }

        public virtual ICollection<ActividadTipoDocumento> ActividadTipoDocumentos { get; set; }
        //public virtual ICollection<DocumentoDatoNumeracion> DocumentoDatoNumeracion { get; set; }
    }
}
