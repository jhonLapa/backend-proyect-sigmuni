using Jca.Sigmuni.Application.Dtos.General.Documentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.InformeDocumentos
{
    public class InformeDocumentoDto
    {
        public int Id { get; set; }
        public int IdInformeTecnico { get; set; }
        public int IdDocumento { get; set; }
        public int Flag { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; }
        public virtual  DocumentoB64Dto? Documento { get; set; }

    }
}
