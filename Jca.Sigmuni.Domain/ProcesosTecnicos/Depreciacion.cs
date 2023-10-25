namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class Depreciacion
    {
        public int IdDepreciacion { get; set; }
        public decimal? Porcentaje { get; set; }
        public int? IdAntiguedad { get; set; }
        public int? IdEcs { get; set; }
        public int? IdMep { get; set; }
        public int? IdClasificacionPredio { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public virtual Antiguedad? Antiguedad { get; set; }
        public virtual Ecs? Ecs { get; set; }
        public virtual Mep? Mep { get; set; }
        public virtual ClasificacionPredio? ClasificacionPredio { get; set; }
    }
}
