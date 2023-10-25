namespace Jca.Sigmuni.Application.Dtos.General.ElementosArquitectonicos
{
    public class ElementoArquitectonicoDto
    {
        public int IdElementoArquitectonico { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
       
        public bool? Estado { get; set; } = true;
    }
}
