using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class AutorizacionAnuncio
    {
        public int IdAutorizacionAnuncio { get; set; }
        public int? NumeLados { get; set; }
        public decimal? AreaAutorizada { get; set; }
        public decimal? AreaVerificada { get; set; }
        public string? NumeExpediente { get; set; }
        public string? NumeLicencia { get; set; }
        public int? IdTipoAnuncio { get; set; }
        public int IdFicha { get; set; }
        public int? IdCondicionAnuncio { get; set; } 
        public int? AnioAutorizacion { get; set; }
        public DateTime? FechaExpedicion { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = false;

        public virtual Ficha? Ficha { get; set; }
        public virtual TipoAnuncio? TipoAnuncio { get; set; }
        public virtual CondicionAnuncio? CondicionAnuncio { get; set; }

   
    }
}
