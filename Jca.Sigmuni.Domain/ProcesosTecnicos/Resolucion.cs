namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class Resolucion
    {
        public int IdResolucion { get; set; }
        public string? NumeroResolucion { get; set; }
        public string? Anio { get; set; }
        public string? NumeroPlano { get; set; }
        public int? IdFicha { get; set; }
        public int? IdTipoResolucion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual Ficha Ficha { get; set; }
        public virtual TipoResolucion TipoResolucion { get; set; }
    }
}
