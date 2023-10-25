using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoOtrasInstalaciones;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ValorObraComplementarias
{
    public class ValorObraComplementariaDto
    {
        public int Id { get; set; }
        public int? Anio { get; set; }
        public string? Descripcion { get; set; }
        public string? UnidadMedida { get; set; }
        public decimal? Valor { get; set; }
        public int? Item { get; set; }
        public int? IdTipoOtrasInstalaciones { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }

        public TipoOtraInstalacionDto? TipoOtraInstalacion { get; set; }
    }
}
