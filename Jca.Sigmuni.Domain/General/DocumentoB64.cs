using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.General
{
    public class DocumentoB64
    {
        public int IdDocumentoB64 { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Contenido { get; set; }
        public string? MineType { get; set; }
        public string? Extencion { get; set; }
        public string? NombreOriginal { get; set; }
        public string? UbicacionFisica { get; set; }
        public virtual ICollection<SolicitudRequisito> SolicitudRequisito { get; set; }
    }
}
