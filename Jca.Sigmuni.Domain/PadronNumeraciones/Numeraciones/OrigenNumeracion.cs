using Jca.Sigmuni.Domain.Base;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.PadronNumeraciones.Numeraciones
{
    public class OrigenNumeracion //: ModelBase<int>
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public bool Flag { get; set; } = false;

        public virtual ICollection<Numeracion> Numeraciones { get; set; }
    }
}
