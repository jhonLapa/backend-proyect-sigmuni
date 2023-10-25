using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.Zonificaciones
{
    public class LoteZonificacionParametro
    {
        public int Id { get; set; }
        public string IdLote { get; set; }
        public int IdZonificacionParametro { get; set; }
        public string? AlineamientoFachada { get; set; }
        public string? UbiCHL { get; set; }
        public string? UbiZRE { get; set; }
        public string? Normativa { get; set; }
        public int? IdClasificacionBien { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        //public virtual Lote Lote { get; set; }
        public virtual ZonificacionParametro ZonificacionParametro { get; set; }
        //public virtual ClasificacionBien ClasificacionBien { get; set; }
    }
}
