using Jca.Sigmuni.Domain.Habilitaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class UbicacionPredio
    {
        public int IdUbicacionPredio { get; set; }
        public string? DenominacionPredio { get; set; }
        public int IdEdificacion { get; set; }
        public int? IdHabilitacionUrbana { get; set; }
        public int IdFicha { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual Edificacion? Edificacion { get; set; }
        public virtual HabilitacionUrbana? HabilitacionUrbana { get; set; }
        public virtual Ficha? Ficha { get; set; }

        public virtual ICollection<Puerta>? Puertas { get; set; }
    }
}
