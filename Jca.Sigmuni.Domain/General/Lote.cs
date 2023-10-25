
﻿using Jca.Sigmuni.Domain.TramiteDocumentario;
﻿using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.Zonificaciones;
using Jca.Sigmuni.Domain.Jurisdiccion;

namespace Jca.Sigmuni.Domain.General
{
    public class Lote
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


        public virtual ICollection<SolicitudCuc>? SolicitudCuc { get; set; }


        public virtual ICollection<Domicilio> Domicilios { get; set; }
        public virtual ICollection<UnidadCatastral> UnidadCatastral { get; set; }
        //public virtual ICollection<LoteZonificacionParametro> LoteZonificacionParametros { get; set; }
        public virtual ICollection<JurisdiccionLote>? JurisdiccionLote { get; set; }


        public virtual Manzana Manzana { get; set; }
    }
}
