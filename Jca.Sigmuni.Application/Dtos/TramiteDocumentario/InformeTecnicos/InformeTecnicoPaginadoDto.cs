using Jca.Sigmuni.Application.Dtos.Admins.Users;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Solicitudes;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoInformes;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.InformeTecnicos
{
    public class InformeTecnicoPaginadoDto
    {
        public int? Id { get; set; }
        public string? NumCorrelativo { get; set; }
        public DateTime? FechaInforme { get; set; }
        public int? Flag { get; set; }
        public int? IdSolicitud { get; set; }
        public int? IdEspecialista { get; set; }
        public int? IdTipoInforme { get; set; }
        public string? JsonDatosSolicitud { get; set; }
        public string? JsonNumeracion { get; set; }
        public string? JsonZonificacion { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public bool? Estado { get; set; }
        public string? EstadoNombre { get; set; }
        public  SolicitudDto? Solicitud { get; set; }
        public  TipoInformeDto? TipoInforme { get; set; }
        public  UsuarioDto? Especialista { get; set; }
    }
}
