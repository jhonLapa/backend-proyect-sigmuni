namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class ExoneracionPredio
    {
        public int IdExoneracionPredio { get; set; }
        public int? IdCondicionEspecialPredio { get; set; }
        public string? NumeroResolucion { get; set; }
        public decimal? Porcentaje { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string? AnioResolucion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual CondicionEspecialPredio CondicionEspecialPredio { get; set; }

        public virtual ICollection<CaracteristicaTitularidad> CaracteristicaTitularidades { get; set; }
    }
}
