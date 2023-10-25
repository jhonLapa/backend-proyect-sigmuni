using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.Expedientes;
using Jca.Sigmuni.Application.Dtos.General.Documentos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.InformeTecnicos
{
    public class InformeDocumento
    {

        [Required(ErrorMessage = "ID Informe Requerido")]
        public int IdInformeTecnico { get; set; }
        [Required(ErrorMessage = "ID documento requerido")]
        public int IdDocumentoB64 { get; set; }

        public int Flag { get; set; }

        public string? Descripcion { get; set; }

        public DocumentoB64FormDto Documento { get; set; }

    }
}
