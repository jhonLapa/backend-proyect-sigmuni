using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.ReintegroSolicitudes
{
    public class ReintegroSolicitudDto
    {
        public int Id { get; set; }
        public Decimal? Importe { get; set; }
        public string NumeroRecibo { get; set; }
        public int? IdSolicitud { get; set; }
        public DateTime? FechaRecibo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; } = true;
    }
}
