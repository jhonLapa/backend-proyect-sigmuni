namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class TipoDocumentoFicha
    {
        public int IdTipoDocumentoFicha { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public string? Grupo { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual ICollection<FichaDocumento> FichaDocumentos { get; set; }
    }
}
