using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.InfDocumentos;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.TipoPrestamo;
using Jca.Sigmuni.Application.Dtos.General.Personas;

namespace Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.TramiteDocumentos
{
    public class TramiteDocumentoDto
    {
        public int Id { get; set; }
        public string? Numero { get; set; }
        public string? Anio { get; set; }
        public DateTime? FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public int? IdInfDocumento { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdSolicitante { get; set; }
        public int? FlagDevuelto { get; set; }
        public int? FoliosPrestados { get; set; }
        public int? FoliosDevueltos { get; set; }
        public string? DocumentoSolicita { get; set; }
        public string? DocumentoRetorna { get; set; }
        public int IdTipoPrestamo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }
        public string? EstadoNombre { get; set; }
        public bool? FlagPrestamo { get; set; }
        public bool? FlagCopiaDigital { get; set; }
        public bool? FlagConsulta { get; set; }

        public InfDocumentoDto? InfDocumento { get; set; }
        public TipoPrestamoDto? TipoPrestamo { get; set; }
        public PersonaDto? persona { get; set; }
    }
}
