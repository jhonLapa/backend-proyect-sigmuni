namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class DocumentoObra
    {
        public int IdDocumentoObra { get; set; }
        public string? NumeroDocumento { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Piso { get; set; }
        public int? IdFicha { get; set; }
        public int? IdTipoDocumentoObra { get; set; }
        public decimal? AreaAutorizada { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual Ficha Ficha { get; set; }
        public virtual TipoDocumentoObra TipoDocumentoObra { get; set; }
    }
}
