using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.SerieDocumental;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.SubSerieDocumental;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.TipoDocumental;
using Jca.Sigmuni.Application.Dtos.General.SeccionDocumentals;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Solicitudes;

namespace Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.InfDocumentos
{
    public class InfDocumentoDto
    {
        public int Id { get; set; }
        public string? NumRegistro { get; set; }
        public string? RazonSocial { get; set; }
        public string? Asunto { get; set; }
        public string? InformacionRelevante { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaTermino { get; set; }
        public string? NumFolios { get; set; }
        public string? TotalImagenes { get; set; }
        public string? Mayora3 { get; set; }
        public string? TapaContratapa { get; set; }
        public string? NumUnidadCaja { get; set; }
        public string? Anio { get; set; }
        public string? Observaciones { get; set; }
        public string? NumModulo { get; set; }
        public string? Lado { get; set; }
        public string? NumCuerpo { get; set; }
        public string? NumBalda { get; set; }
        public int IdSolicitud { get; set; }
        public int IdSeccionDocumento { get; set; }
        public int IdTipoDocumental { get; set; }
        public int IdSerieDocumental { get; set; }
        public int IdSubSerieDoc { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }
        public string? EstadoNombre { get; set; }
        public string? NumCaja { get; set; }
        public string? NumConcatRegistro { get; set; }

        public  TipoDocumentalDto? TipoDocumental { get; set; }
        public  SerieDocumentalDto? SerieDocumental { get; set; }
        public SubSerieDocumentalDto? SubSerieDocumental { get; set; }
        public SeccionDocumentalDto? SeccionDocumental { get; set; }
        public SolicitudDto? Solicitud { get; set; }
    }
}
