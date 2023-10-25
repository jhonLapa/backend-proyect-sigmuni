namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.MedioRegistros
{
    public class MedioRegistroDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }
        public string EstadoNombre { get; set; }
    }
}
