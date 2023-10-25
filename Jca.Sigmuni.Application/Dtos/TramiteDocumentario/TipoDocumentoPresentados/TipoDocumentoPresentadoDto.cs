namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoDocumentoPresentados
{
    public class TipoDocumentoPresentadoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }
        public string EstadoNombre { get; set; }
    }
}
