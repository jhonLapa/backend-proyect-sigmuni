using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Procedimientos
{
    public class AsuntoDto
    {
        public int Id { get; set; }
        public string? AsuntoTramite { get; set; }
        public string? Descripcion { get; set; }
    }
}
