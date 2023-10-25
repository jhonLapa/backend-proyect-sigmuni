using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.TramiteDocumentos
{
    public class TramiteDocumentoFormDto
    {
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
        public bool? FlagPrestamo { get; set; }
        public bool? FlagCopiaDigital { get; set; }
        public bool? FlagConsulta { get; set; }
    }
}
