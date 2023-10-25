namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoDocumentosFichas
{
    public class TipoDocumentoFichaDto
    {
        public int IdTipoDocumentoFicha { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public string? Grupo { get; set; }

        
        public bool? Estado { get; set; } = true;
    }
}
