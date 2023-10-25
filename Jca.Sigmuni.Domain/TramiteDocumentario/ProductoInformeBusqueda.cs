using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class ProductoInformeBusqueda
    {

        public string? NumeroExpediente { get; set; }
        public int? IdTipoTramite { get; set; }

        public int? IdProcedimiento { get; set; }
        public bool? Estado { get; set; }

        public string? Nombre { get; set; }

        public string? FechaRegistroDesde { get; set; }
        public string? FechaRegistroHasta { get; set; }
        public string? AsuntoTramite { get; set; }
        public string? TipoTramite { get; set; }

        public int? IdInformeTecnico { get; set; }
        public int? IdProducto { get; set; }

        public int? IdDocumento { get; set; }
        public int? IdDocumentoInforme { get; set; }
        public DateTime? FechaEmision { get; set; }



    }
}
