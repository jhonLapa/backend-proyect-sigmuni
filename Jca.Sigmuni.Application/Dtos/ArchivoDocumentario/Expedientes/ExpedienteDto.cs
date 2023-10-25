using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.TipoDocumental;
using Jca.Sigmuni.Application.Dtos.General.Documentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.Expedientes
{
    public class ExpedienteDto
    {
        public int Id { get; set; }
        public int IdDocumento { get; set; }
        public int IdInfDocumento { get; set; }
        public int Folios { get; set; }
        public bool? Estado { get; set; }
        public DocumentoB64FormDto? Documento { get; set; }
        //public string NombreDocumento { get; set; }
        //public DocumentoB64Dto Documento { get; set; }
        //public List<MarcadorDto> Marcador { get; set; }
    }
}
