namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoDocumentoObras
{
    public class TipoDocumentoObraDto
    {
        public int IdTipoDocumentoObra { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
    }
}
