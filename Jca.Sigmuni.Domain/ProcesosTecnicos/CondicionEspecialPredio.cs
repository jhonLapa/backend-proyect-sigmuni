namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class CondicionEspecialPredio
    {
        public int IdCondicionEspecialPredio { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual ICollection<ExoneracionPredio> ExoneracionPredios { get; set; }
    }
}
