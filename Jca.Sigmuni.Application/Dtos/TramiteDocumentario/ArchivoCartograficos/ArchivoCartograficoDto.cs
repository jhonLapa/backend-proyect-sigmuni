namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.ArchivoCartograficos
{
    public class ArchivoCartograficoDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int IdDocumento { get; set; }
        public int IdSolicitud { get; set; }
        public int flag { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }
        public string EstadoNombre { get; set; }
        //public virtual Documento Documento { get; set; }
    }
}
