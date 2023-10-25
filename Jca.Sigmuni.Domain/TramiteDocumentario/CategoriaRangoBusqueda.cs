using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class CategoriaRangoBusqueda
    {
        public DateTime? FechaRegistro { get; set; }

        public int? IdProcedimiento { get; set; }
        public bool? Estado { get; set; }
        public int? IdTipoTramite { get; set; }
        public string? FechaRegistroDesde { get; set; }
        public string? FechaRegistroHasta { get; set; }
        public string? AsuntoTramite { get; set; }

        public int? Anio { get; set; }
        public string? TipoTramite { get; set; }
    }
}
