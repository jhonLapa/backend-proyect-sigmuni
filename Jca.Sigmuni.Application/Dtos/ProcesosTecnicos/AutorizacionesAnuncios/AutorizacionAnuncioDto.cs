using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionAnuncios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoAnuncios;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.AutorizacionesAnuncios
{
    public class AutorizacionAnuncioDto
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


        public TipoAnuncioDto? TipoAnuncio { get; set; }
        public CondicionAnuncioDto? CondicionAnuncio { get; set; }
    }
}
