namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class FormaAdquisicion
    {
        public int IdFormaAdquisicion { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual ICollection<CaracteristicaTitularidad> CaracteristicaTitularidades { get; set; }
    }
}
