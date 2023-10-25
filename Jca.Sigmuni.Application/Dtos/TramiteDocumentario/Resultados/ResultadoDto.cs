namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Resultados
{
    public class ResultadoDto 
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Grupo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }
        public string EstadoNombre { get; set; }
    }
}
