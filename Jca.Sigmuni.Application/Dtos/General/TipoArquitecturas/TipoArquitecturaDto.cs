namespace Jca.Sigmuni.Application.Dtos.General.TipoArquitecturas
{
    public class TipoArquitecturaDto
    {
        public int IdTipoArquitecturas { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; } = true;
    }
}
