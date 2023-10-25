using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class ReintegroSolicitud
    {
        public int Id { get; set; }
        public Decimal? Importe { get; set; }
        public string NumeroRecibo { get; set; }
        public int? IdSolicitud { get; set; }
        public DateTime? FechaRecibo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; } = true;

        //public virtual Solicitud Solicitud { get; set; }

        public ReintegroSolicitud()
        {
            FechaRegistro = DateTime.UtcNow;
        }
    }
}
