
using Jca.Sigmuni.Domain.ProcesosTecnicos;

using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Domain.CompendioNormas
{
    public class NormaInteres
    {
        public int IdNormaInteres { get; set; }
        public string? PaginasInteres { get; set; }
        public string? observacion { get; set; }
        public long? IdNormaDerogado { get; set; }
        public string? ArticuloNormaDerogado { get; set; }
        public string? ObservacionNormaDerogado { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        public int IdNormaDiaDetalle { get; set; }
        public int? IdAutoridad { get; set; }
        public int IdNaturaleza { get; set; }
        public bool? EstadoNotificacion { get; set; } = true;
        public int IdDocumento { get; set; }
        public int IdEstadoNorma { get; set; }
        public int IdEstadoDerogado { get; set; }
        public int IdClasificacion { get; set; }
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Sumilla { get; set; }
        public int IdTipoNorma { get; set; }

        public virtual NormaDiaDetalle? NormaDiaDetalles { get; set; }

        public virtual ICollection<NormaIntMonColonial> NormaIntMonColonial { get; set; }
        public virtual ICollection<NormaIntMonPrehi> NormaIntMonPreins { get; set; }
        public virtual ICollection<NormaDerogada> NormaDerogadas { get; set; }
        public virtual ICollection<NormaDerogada> NormaInteresDerogadas { get; set; }

        public virtual ICollection<ProcedimientoNormaInteres> ProcedimientoNormaInteres { get; set; }

    }
}
