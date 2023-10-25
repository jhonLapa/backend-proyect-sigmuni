using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class SolicitudBusqueda
    {
        public int Id { get; set; }
        public string? NumeroExpediente { get; set; }
        public string? NumeroSolicitud { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string? FechaRegistroDesde { get; set; }
        public string? FechaRegistroHasta { get; set; }
        public bool? Estado { get; set; }
        public int? IdProcedimiento { get; set; }
        public int? IdTipoPersona { get; set; }
        public string? TipoPersona { get; set; }
        public string? NumDoc { get; set; }
        public string? Nombres { get; set; }
        public string? TipoTramite { get; set; }
        public string? Asunto { get; set; }
        public int? AnioSolicitud { get; set; }
        public int? IdTipoDocumentoSimple { get; set; }
        public string? Solicitante { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? TipoDocumento { get; set; }
        public int? IdTipoTramite { get; set; }
        public int? IdArea { get; set; }
        public string? DocumentoSimple { get; set; }



    }
}
