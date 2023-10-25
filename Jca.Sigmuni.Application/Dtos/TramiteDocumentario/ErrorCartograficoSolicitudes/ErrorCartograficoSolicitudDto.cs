using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Solicitudes;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.ErrorCartograficoSolicitudes
{
    public class ErrorCartograficoSolicitudDto
    {
        public int Id { get; set; }
        public int IdSolicitud { get; set; }
        public int NroRevision { get; set; }
        public int Conformidad { get; set; }
        public string Observacion { get; set; }
        public int? flag { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }
        public string EstadoNombre { get; set; }
        public virtual SolicitudDto Solicitud { get; set; }
    }
}
