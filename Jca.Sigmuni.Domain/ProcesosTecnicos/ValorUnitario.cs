namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class ValorUnitario
    {
        public int IdValorUnitario { get; set; }
        public int? Anio { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Valor { get; set; }
        public int? IdClasificacionValUnitario { get; set; }
        public int? IdCategoriaValUnitario { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual CategoriaConstruccion? CategoriaValorUnitario { get; set; }
        public virtual ClasificacionValorUnitario? ClasificacionValorUnitario { get; set; }
    }
}
