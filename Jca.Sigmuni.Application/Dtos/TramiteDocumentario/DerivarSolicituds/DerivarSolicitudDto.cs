using Jca.Sigmuni.Application.Dtos.Admins.Users;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TramiteSolicituds;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.DerivarSolicituds
{
    public class DerivarSolicitudDto
    {
        public int Id { get; set; }
        public int IdTramiteSolicitud { get; set; }
        public int IdRemitente { get; set; }
        public string Descripcion { get; set; }
        public string Duracion { get; set; }
        public DateTime FechaEnvio { get; set; }
        public int? IdDocumento { get; set; }
        public int IdArea { get; set; }
        public int IdDestinatario { get; set; }
        public string Observacion { get; set; }

        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }
        public string EstadoNombre { get; set; }

        public virtual TramiteSolicitudDto TramiteSolicitud { get; set; }
        //public virtual Documento Documento { get; set; }
        public virtual UsuarioDto Remitente { get; set; }
        public virtual UsuarioDto Destinatario { get; set; }
    }
}
