namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class Antiguedad
    {
        public int IdAntiguedad { get; set; }
        public string? PrimeraCondicion { get; set; }
        public int? LimiteInferior { get; set; }
        public string? SegundaCondicion { get; set; }
        public int? LimiteSuperior { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual ICollection<Depreciacion>? Depreciacion { get; set; }
    }
}
