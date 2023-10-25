using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class OtraInstalacion
    {
        public int IdOtraInstalacion { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? ProductoTotal { get; set; }
        public int? IdUca { get; set; }
        public int? IdTipoOtrasInstalaciones { get; set; }
        public int IdFicha { get; set; }
        public int? IdEcc { get; set; }
        public int? IdEcs { get; set; }
        public int? IdMep { get; set; }
        public int? IdUnidadMedida { get; set; }
        public double? Largo { get; set; }
        public double? Ancho { get; set; }
        public double? Alto { get; set; }
        public DateTime? MesAnio { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual TipoOtraInstalacion? TipoOtraInstalacion { get; set; }
        public virtual Mep? Mep { get; set; }
        public virtual Ecs? Ecs { get; set; }
        public virtual Ecc? Ecc { get; set; }
        public virtual Uca? Uca { get; set; }
        public virtual Ficha? Ficha { get; set; }
        public virtual UnidadMedida? UnidadMedida { get; set; }
    }
}
