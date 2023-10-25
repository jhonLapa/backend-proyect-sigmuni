using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TIpoNormas
{
    public class TipoNormaDto
    {
        public int IdTipoNorma { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public float? flag { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
    }
}
