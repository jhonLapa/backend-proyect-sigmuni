using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.InfDocumentos
{
    public class InfDocumentoSPFormDto
    {
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
        public string? NumCaja { get; set; }
        public string? NumConcatRegistro { get; set; }
    }
}
