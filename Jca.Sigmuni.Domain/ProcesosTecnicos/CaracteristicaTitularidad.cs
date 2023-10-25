namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class CaracteristicaTitularidad
    {
        public int IdCaracteristicaTitularidad { get; set; }
        public int? IdCondicionTitular { get; set; }
        public int? IdFormaAdquisicion { get; set; }
        public int? IdExoneracionPredio { get; set; }
        public string? CondicionTitularOtros { get; set; }
        public string? FormaAdquisicionOtros { get; set; }
        public string? PorcentajeTitularidad { get; set; }
        public DateTime? FechaAdquisicion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual CondicionTitular CondicionTitular { get; set; }
        public virtual FormaAdquisicion FormaAdquisicion { get; set; }
        public virtual ExoneracionPredio ExoneracionPredio { get; set; }    

        public virtual ICollection<TitularCatastral> TitularCatastrales { get; set; }
    }
}
