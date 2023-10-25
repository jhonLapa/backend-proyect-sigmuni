using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.Expedientes;
using Jca.Sigmuni.Application.Dtos.General.Documentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.Marcadores
{
    public class MarcadorExpedienteDto
    {
        public ExpedienteFormDto Expediente { get; set; }
        public List<MarcadorFormDto>? Marcadores { get; set; }
        public MarcadorFormDto? Marcador { get; set; }

        public DocumentoB64FormDto Documento { get; set; }



    }
}
