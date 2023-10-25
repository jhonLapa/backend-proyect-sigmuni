using Jca.Sigmuni.Domain.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class Edificacion
    {
        public int IdEdificacion { get; set; }
        public string? Nombre { get; set; }
        public string? Manzana { get; set; }
        public string? NumLote { get; set; }
        public string? LoteUrbano { get; set; }
        public string? SubLote { get; set; }
        public int? IdTipoEdificacion { get; set; }
        public int? IdTipoAgrupacion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual TipoEdificacion TipoEdificacion { get; set; }
        public virtual TipoAgrupacion TipoAgrupacion { get; set; }

        public virtual ICollection<UbicacionPredio> UbicacionPredios { get; set; }
        public virtual ICollection<Domicilio> Domicilio { get; set; }
    }
}
