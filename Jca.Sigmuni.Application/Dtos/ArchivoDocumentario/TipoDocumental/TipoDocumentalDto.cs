using Jca.Sigmuni.Domain.ArchivoDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.TipoDocumental
{
    public class TipoDocumentalDto
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public string? Siglas { get; set; }
    }
}
