namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.AreaActividadesEconomicas
{
    public class AreaActividadEconomicaDto
    {
        public int IdAreaActividadEconomica { get; set; }
        public decimal? PredioCatAutorizada { get; set; }
        public decimal? PredioCatVerificada { get; set; }
        public decimal? ViaPubAutorizada { get; set; }
        public decimal? ViaPubVerificada { get; set; }
        public decimal? BienComunAutorizada { get; set; }
        public decimal? BienComunVerificada { get; set; }
        public decimal? TotalAutorizada { get; set; }
        public decimal? TotalVerificada { get; set; }
        public string? NumExpediente { get; set; }
        public string? NumLicencia { get; set; }
        public DateTime? FechaExpedicion { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public DateTime? InicioActividad { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = false;
        public int IdFicha { get; set; }
        public string? NumResolucion { get; set; }
        public int? CodCatAsigCorrect { get; set; }

        public int? AnioAutorizacion { get; set; }

        
    }
}
