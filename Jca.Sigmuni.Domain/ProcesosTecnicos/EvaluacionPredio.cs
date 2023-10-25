namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class EvaluacionPredio
    {
        public int IdEvaluacionPredio { get; set; }
        public decimal? Area { get; set; }
        public int IdTipoEvaluacion { get; set; }
        public int IdFicha { get; set; }

        public virtual Ficha Ficha { get; set; }
        public virtual TipoEvaluacion TipoEvaluacion { get; set; }
    }
}
