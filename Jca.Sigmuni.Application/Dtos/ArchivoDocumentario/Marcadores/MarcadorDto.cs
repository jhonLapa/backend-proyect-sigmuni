using Jca.Sigmuni.Domain.ArchivoDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.Marcadores
{
    public class MarcadorDto
    {
        public int Id { get; set; }
        public int Pagina { get; set; }
        public string? Descripcion { get; set; }
        public int IdExpediente { get; set; }
    }
}
