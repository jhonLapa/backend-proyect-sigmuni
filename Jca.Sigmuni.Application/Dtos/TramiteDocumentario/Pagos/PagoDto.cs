using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.MedioPagos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Monedas;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Pagos
{
    public class PagoDto
    {
        public int Id { get; set; }
        public string? NumeroRecibo { get; set; }
        public int? NumeroOperacion { get; set; }
        public Decimal? Importe { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Hora { get; set; }
        public int? IdSolicitud { get; set; }
        public int? IdMedioPago { get; set; }
        public int? IdMoneda { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public bool? Estado { get; set; }
        public MedioPagoDto? MedioPago { get; set; }
        public MonedaDto? Moneda { get; set; }  
    }
}
