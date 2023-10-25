using Jca.Sigmuni.Application.Dtos.General.Manzanas;

namespace Jca.Sigmuni.Application.Dtos.General.Lotes
{
    public class LoteDto
    {
        public string Id { get; set; }
        public string? Codigo { get; set; }
        public string? CUC { get; set; }
        public DateTime? FechaEdicion { get; set; }
        public string? Editor { get; set; }
        public string? Observacion { get; set; }
        public double? AreaGrafica { get; set; }
        public double? AreaConstruida { get; set; }
        public string? EstadoObservacion { get; set; }
        public string? NumeroPartidaRegistral { get; set; }
        public string? VersionFinal { get; set; }
        public int? IdUbicacionLote { get; set; }
        public int? IdEstructura { get; set; }
        public int? ValorArancelario { get; set; }

        public string? Anio { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        public string? IdManzanaCarto { get; set; }
        public ManzanaDto Manzana { get; set; }

        // public virtual ManzanaDto Manzana { get; set; }
    }
}
