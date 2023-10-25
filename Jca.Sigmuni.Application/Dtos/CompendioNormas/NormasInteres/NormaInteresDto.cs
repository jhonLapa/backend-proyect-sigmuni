using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.CompendioNormas.NormasInteres
{
    public class NormaInteresDto
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
        public string? FechaRegistroDesde { get; set; }
        public string? FechaRegistroHasta { get; set; }
        public int IdNormaDiaDetalle { get; set; }
        public int? IdAutoridad { get; set; }
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
        public List<NormaDerogadaDto>? NormaDerogada{ get;set; }
        public List<NormaDerogadaDto>? NormaDerogadas { get; set; }
    }
}
