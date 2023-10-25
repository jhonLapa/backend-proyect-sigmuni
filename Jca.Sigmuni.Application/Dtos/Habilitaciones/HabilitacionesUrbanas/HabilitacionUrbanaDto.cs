using Jca.Sigmuni.Application.Dtos.General.Ubigeos;
using Jca.Sigmuni.Application.Dtos.Habilitaciones.TipoHabilitacionesUrbanas;

namespace Jca.Sigmuni.Application.Dtos.Habilitaciones.HabilitacionesUrbanas
{
    public class HabilitacionUrbanaDto
    {
        public int IdHabilitacionUrbana { get; set; }

        
        public string? CodigoHabilitacioUrbana { get; set; }
        public string? Nombre { get; set; }
        public string? CodigoUbigeo { get; set; }
        //public int IdTipoHabilitacionUrbana { get; set; }
        public int? IdTipoHabilitacionUrbana { get; set; }
        public int? IdEtapaHabilitacionUrbana { get; set; }
        public string? IdHUCarto { get; set; }
        public string? PropietarioHistorico { get; set; }
        public string? PredioMatriz { get; set; }
        public string? NumeroExpediente { get; set; }
        public string? ResolucionLicencia { get; set; }
        public string? ResolucionRecepcion { get; set; }
        public DateTime? FechaRegistro { get; set; }
        //public DateTime? FechaAprobacion { get; set; }
        //public DateTime FechaEmision { get; set; }
        //public DateTime? FechaEmision { get; set; }
        public string? CodigoOrden { get; set; }
        public string? PartidaParcelaRegistral { get; set; }
        public string? Nota { get; set; }
        public string? Fundo { get; set; }
        public string? SubLote { get; set; }
        
        public int? IdUsuario { get; set; }
        public string? Ip { get; set; }
        //public string SeccionVialAprobada { get; set; }
        //public string NumeroPlanoAprobado { get; set; }
        //public DateTime FechaAprobacionPlano { get; set; }
        public bool? Estado { get; set; }
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        //public string IdPersona { get; set; }
        // public LinderosHabilitacionesUrbanaDto LinderosHabilitacionesUrbana { get; set; }
        // public virtual List<FactibilidadServiciosHabilitacionesUrbanaDto> FactibilidadServiciosHabilitacionesUrbana { get; set; }
        //public AreaHabilitacionUrbanaDto AreaHabilitacionUrbana { get; set; }
        //public HabilitacionesUrbanaNormaInteresDto HabilitacionesUrbanaNormaInteres { get; set; }
        //////////////////////////////
        public TipoHabilitacionUrbanaDto? TipoHabilitacionUrbana { get; set; }
       // public EtapaHabilitacionUrbanaDto EtapaHabilitacionUrbana { get; set; }
        //public PersonaDto Persona { get; set; }
       // public UbicacionPredioDto UbicacionPredio { get; set; }
       // public virtual List<HabilitacionesUrbanasDocumentoDto> HabilitacionesUrbanasDocumento { get; set; }
       // public virtual List<HabilitacionesUrbanaNormaInteresDto> HabilitacionesUrbanaNormaInteres { get; set; }
       // public virtual List<AporteReglamentarioDto> AporteReglamentario { get; set; }
       // public EstadoHUDto EstadoHU { get; set; }
        public UbigeoDto? Ubigeo { get; set; }
       // public virtual List<LinderoLotesHailitacionesUrbanasDto> LinderoLotesHailitacionesUrbanas { get; set; }
    }
}
