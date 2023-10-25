using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.Habilitaciones
{
    public class HabilitacionUrbana
    {
        public int IdHabilitacionUrbana { get; set; }
        public string? CodigoHabilitacioUrbana { get; set; }
        public string? Nombre { get; set; }
        public string? CodigoUbigeo { get; set; }
        public int? IdTipoHU { get; set; }
        public int? IdEtapaHU { get; set; }
        public int? IdEstadoHU { get; set; }
        public string? IdHUCarto { get; set; }
        public string? PropietarioHistorico { get; set; }
        public string? PredioMatriz { get; set; }
        public string? NumeroExpediente { get; set; }
        public string? ResolucionLicencia { get; set; }
        public string? ResolucionRecepcion { get; set; }
        public int? IdUsuario { get; set; }
        public int? NumTotalManzanas { get; set; }
        public int? NumTotalLotes { get; set; }
        //public DateTime? FechaAprobacion { get; set; }
        //public DateTime? FechaAprobacionHU { get; set; }
        //public DateTime? FechaActualizacion { get; set; }
        public string? CodigoOrden { get; set; }
        public string? PartidaParcelaRegistral { get; set; }
        public string? Nota { get; set; }
        public string? Fundo { get; set; }
        public string? SubLote { get; set; }
        //public string SeccionVialAprobada { get; set; }
        //public string NumeroPlanoAprobado { get; set; }
        //public DateTime FechaAprobacionPlano { get; set; }
        public DateTime? FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public int? IdPersona { get; set; }
        public int? IdAccion { get; set; }

        public virtual Ubigeo? Ubigeo { get; set; }
        public virtual TipoHabilitacionUrbana? TipoHabilitacionUrbana { get; set; }
        //public virtual EtapaHabilitacionUrbana EtapaHabilitacionUrbana { get; set; }
        // public virtual EstadoHU EstadoHU { get; set; }
        public virtual Persona? Persona { get; set; }
        // public virtual AreaHabilitacionUrbana AreaHabilitacionUrbana { get; set; }
        //public virtual LinderosHabilitacionesUrbana LinderosHabilitacionesUrbana { get; set; }



        //public virtual ICollection<Lote> Lote { get; set; }
        //public virtual ICollection<LoteHabilitacionesUrbanas> LoteHabilitacionParametro { get; set; }
        //public virtual ICollection<Via> Via { get; set; }

        public virtual ICollection<Domicilio>? Domicilio { get; set; }
        // public virtual ICollection<HabilitacionesUrbanasDocumento> HabilitacionesUrbanasDocumento { get; set; }
        // public virtual ICollection<HabilitacionesUrbanaNormaInteres> HabilitacionesUrbanaNormaInteres { get; set; }
        // public virtual ICollection<FactibilidadServiciosHabilitacionesUrbana> FactibilidadServiciosHabilitacionesUrbana { get; set; }

        // public virtual ICollection<AporteReglamentario> AporteReglamentarios { get; set; }
        // public virtual ICollection<LinderoLotesHailitacionesUrbanas> LinderoLotesHailitacionesUrbanas { get; set; }
        public virtual ICollection<UbicacionPredio>? UbicacionPredios { get; set; }
    }
}
