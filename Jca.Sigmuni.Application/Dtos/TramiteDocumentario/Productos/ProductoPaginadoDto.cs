using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Solicitudes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Productos
{
    public class ProductoPaginadoDto
    {
        public int Id { get; set; }
        public string? NumCorrelativo { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaCaducidad { get; set; }
        //[Required(ErrorMessage = "Tipo Certificado es requerido (FLAG)")]
        public int Flag { get; set; }
        //[Required(ErrorMessage = "ID Solicitud es requerido")]
        public int IdSolicitud { get; set; }
        public string? NumInforme { get; set; }
        public string? NumPlanoZonificacion { get; set; }
        public string? NumPlanoVia { get; set; }
        //[Required(ErrorMessage = "Json Certificado es requerido")]
        public string JsonProducto { get; set; }
        public int? IdDocumento { get; set; }
        public bool? EsProducto { get; set; }

        public SolicitudDto? Solicitud { get; set; }
    }
}
