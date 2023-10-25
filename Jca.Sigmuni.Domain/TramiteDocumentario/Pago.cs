using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class Pago
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
        public bool? Estado { get; set; } = true;
        public virtual MedioPago? MedioPago { get; set; }
        public virtual Moneda? Moneda { get; set; }
        public virtual Solicitud? Solicitud { get; set; }
        public Pago()
        {
            FechaRegistro = DateTime.UtcNow;
        }
    }
}
