using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.CompendioNormas
{
    public class NormaInteresB64
    {
        public int IdNormaInteresB64 { get; set; }
        public string? PaginasInteres { get; set; }
        public string? observacion { get; set; }
        public int IdNormaDerogado { get; set; }
        public string? ArticuloNormaDerogado { get; set; }
        public string? ObservacionNormaDerogado { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public int IdNormaDiaDetalle { get; set; }
        public int IdAutoridad { get; set; }
        public int IdNaturaleza { get; set; }
        public bool? EstadoNotificacion { get; set; }
        public int IdDocumento { get; set; }
        public int IdEstadoNorma { get; set; }
        public int IdEstadoDerogado { get; set; }
        public int IdClasificacion { get; set; }
        public int IdUsuario { get; set; }
    }
}
