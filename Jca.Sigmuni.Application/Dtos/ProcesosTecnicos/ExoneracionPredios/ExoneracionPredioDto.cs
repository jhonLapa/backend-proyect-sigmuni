using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesEspecialesPredios;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ExoneracionPredios
{
    public class ExoneracionPredioDto
    {
        public int IdExoneracionPredio { get; set; }
        public int? IdCondicionEspecialPredio { get; set; }
        public string? NumeroResolucion { get; set; }
        public decimal? Porcentaje { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string? AnioResolucion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }

        public virtual CondicionEspecialPredioDto? CondicionEspecialPredio { get; set; }
    }
}
