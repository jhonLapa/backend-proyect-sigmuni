using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.ArchivoDocumentario
{
    public class InfDocumento
    {
        public int Id { get; set; }
        public string? NumRegistro { get; set; }
        public string? RazonSocial { get; set; }
        public string? Asunto { get; set; }
        public string? InformacionRelevante { get;set; }
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
        public int? IdSolicitud { get; set; }
        public int IdSeccionDocumento { get; set; }
        public int? IdTipoDocumental { get; set; }
        public int? IdSerieDocumental { get; set; }
        public int? IdSubSerieDoc { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string? EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        public string? NumCaja { get; set; }
        public string? NumConcatRegistro { get; set; }
        public virtual TipoDocumental? TipoDocumental { get; set; }
        public virtual SerieDocumental? SerieDocumental { get; set; }
        public virtual SubSerieDocumental? SubSerieDocumental { get; set; }
        public virtual SeccionDocumental? SeccionDocumental { get; set; }
        public virtual Solicitud? Solicitud { get; set; }
        public virtual ICollection<TramiteDocumento> TramiteDocumento { get; set; }
        public virtual ICollection<Expediente> Expediente { get; set; }



    }
}
