namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas
{
    public class FichaDto
    {
        public int IdFicha { get; set; }
        public string? NumExpediente { get; set; }
        public string? NtTf { get; set; }
        public string? NumFicha { get; set; }
        public double? Dc { get; set; }
        public int IdTipoFicha { get; set; }
        public int IdUnidadCatastral { get; set; }
        public string IdLoteCarto { get; set; }
        public int? AnioFicha { get; set; }
        public int? IdFichaPadre { get; set; }
        public int? IdFichaIndividualEstatica { get; set; }
        public string? TipoBienComun { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public int? IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }
        public virtual int IdFichaCotitular { get; set; }
        public virtual int IdFichaBienComun { get; set; }
        public virtual int IdFichaEconomica { get; set; }
        public virtual int IdFichaBienCultural { get; set; }
        public List<int>? IdsFichasEconomicas { get; set; }
    }
}
