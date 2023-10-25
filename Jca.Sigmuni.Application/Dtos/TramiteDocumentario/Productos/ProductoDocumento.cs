using Jca.Sigmuni.Application.Dtos.General.Documentos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Productos
{
    public class ProductoDocumento
    {
        [Required(ErrorMessage = "ID producto Requerido")]
        public int Id { get; set; }
        public int IdDocumento { get; set; }


        public DocumentoB64FormDto Documento { get; set; }
    }
}
