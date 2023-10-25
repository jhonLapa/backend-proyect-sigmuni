using Jca.Sigmuni.Domain.PadronNumeraciones.Numeraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class TipoEdificacion
    {
        public int IdTipoEdificacion { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual ICollection<Edificacion> Edificaciones { get; set; }
        public virtual ICollection<Numeracion> Numeraciones { get; set; }
    }
}
