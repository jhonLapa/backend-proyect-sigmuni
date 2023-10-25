using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoEvaluaciones;
using System.Text.Json.Serialization;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EvaluacionPredios
{
    public class EvaluacionPredioDto
    {
        public int IdEvaluacionPredio { get; set; }
        public decimal? Area { get; set; }

        [JsonIgnore]
        public int IdFicha { get; set; }

        public TipoEvaluacionDto TipoEvaluacion { get; set; }
    }
}
