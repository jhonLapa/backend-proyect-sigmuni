using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Eccs;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ecss;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Meps;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoOtrasInstalaciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ucas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UnidadMedidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.OtraInstalaciones
{
    public class OtraInstalacionDto
    {
        public int IdOtraInstalacion { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? ProductoTotal { get; set; }
        public int IdFicha { get; set; }
        public double? Largo { get; set; }
        public double? Ancho { get; set; }
        public double? Alto { get; set; }
        public DateTime? MesAnio { get; set; }

        public UcaDto? Uca { get; set; }
        public TipoOtraInstalacionDto? TipoOtraInstalacion { get; set; }
        public EccDto? Ecc { get; set; }
        public EcsDto? Ecs { get; set; }
        public MepDto? Mep { get; set; }
        public UnidadMedidaDto? UnidadMedida { get; set; }

        // valor obra complementaria
        public decimal? Valor { get; set; }
        public string? UnidadMedidaString { get; set; }
    }
}
