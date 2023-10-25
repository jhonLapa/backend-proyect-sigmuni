using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class TipoOtraInstalacion
    {
        public int IdTipoOtraInstalacion { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int? IdUnidadMedida { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual UnidadMedida? UnidadMedida { get; set; }

        public virtual ICollection<OtraInstalacion>? OtraInstalaciones { get; set; }
        public virtual ICollection<ValorObraComplementaria>? ValorObraComplementarias { get; set; }
    }
}
