using Jca.Sigmuni.Application.Dtos.General.Documentos;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.CompendioNormas.NormasInteres
{
    public class NormaInteresDocumentoDto
    {
        public int IdNormaInteres { get; set; }
        public string? PaginasInteres { get; set; }
        public string? Observacion { get; set; }
        public int IdNormaDerogado { get; set; }
        public string? ArticuloNormaDerogado { get; set; }
        public string? ObservacionNormaDerogado { get; set; }
        public string? ObsModificadoDerogado { get; set; }
        public bool? Estado { get; set; }
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        public DateTime? FechaRegistro { get; set; } = DateTime.UtcNow;
        public int IdNormaDiaDetalle { get; set; }
        public int IdAutoridad { get; set; }
        public int IdNaturaleza { get; set; }
        public bool? EstadoNotificacion { get; set; }
        public int IdDocumento { get; set; }
        public int IdEstadoNorma { get; set; }
        public int IdEstadoDerogado { get; set; }
        public int IdClasificacion { get; set; }
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Sumilla { get; set; }
        public int IdTipoNorma { get; set; }
        public NormaDiaDetalleDto? NormaDiaDetalle { get; set; }
        public DocumentoB64FormDto Documento { get; set; }
    }
}
