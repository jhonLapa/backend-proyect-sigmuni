using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class TramiteDocumento
    {
        public int Id { get; set; }
        public string? Numero { get; set; }
        public string? Anio { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public int IdInfDocumento { get; set; }
        public int IdUsuario { get; set; }
        public int IdSolicitante { get; set; }
        public int FlagDevuelto { get; set; }
        public int FoliosPrestados { get; set; }
        public int FoliosDevueltos { get; set; }
        public string? DocumentoSolicita { get; set; }
        public string? DocumentoRetorna { get; set; }
        public int IdTipoPrestamo { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string? EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        public bool? FlagPrestamo { get; set; }
        public bool? FlagCopiaDigital { get; set; }
        public bool? FlagConsulta { get; set; }

        public virtual InfDocumento? InfDocumento { get; set; }
        public virtual TipoPrestamo? TipoPrestamo { get; set; }
        public virtual Persona? Persona { get; set; }

    }
}
