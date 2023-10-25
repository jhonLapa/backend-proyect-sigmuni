using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class ValorObraComplementaria
    {
        public int Id { get; set; }
        public int? Anio { get; set; }
        public string? Descripcion { get; set; }
        public string? UnidadMedida { get; set; }
        public decimal? Valor { get; set; }
        public int? Item { get; set; }
        public int? IdTipoOtrasInstalaciones { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual TipoOtraInstalacion? TipoOtraInstalacion { get; set; }
    }
}
