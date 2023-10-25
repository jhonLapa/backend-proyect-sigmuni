using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Antiguedades;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ClasificacionesPredios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ecss;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Meps;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Depreciaciones
{
    public class DepreciacionDto
    {
        public int IdDepreciacion { get; set; }
        public decimal? Porcentaje { get; set; }
        public int? IdAntiguedad { get; set; }
        public int? IdEcs { get; set; }
        public int? IdMep { get; set; }
        public int? IdClasificacionPredio { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public bool Estado { get; set; }

        public virtual AntiguedadDto? Antiguedad { get; set; }
        public virtual EcsDto? Ecs { get; set; }
        public virtual MepDto? Mep { get; set; }
        public virtual ClasificacionPredioDto? ClasificacionPredio { get; set; }
    }
}
