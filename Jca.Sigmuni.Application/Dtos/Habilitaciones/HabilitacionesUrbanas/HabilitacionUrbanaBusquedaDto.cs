using Jca.Sigmuni.Application.Dtos.General.Ubigeos;
using Jca.Sigmuni.Application.Dtos.Habilitaciones.TipoHabilitacionesUrbanas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.Habilitaciones.HabilitacionesUrbanas
{
    public class HabilitacionUrbanaBusquedaDto
    {
        public int IdHabilitacionUrbana { get; set; }


        public string? CodigoHabilitacioUrbana { get; set; }
        public string? Nombre { get; set; }
        public string? CodigoUbigeo { get; set; }
        public int? IdTipoHabilitacionUrbana { get; set; }
        public int? IdEtapaHabilitacionUrbana { get; set; }
        public int? IdHUCarto { get; set; }
        public string? PropietarioHistorico { get; set; }
        public string? PredioMatriz { get; set; }
        public string? NumeroExpediente { get; set; }
        public string? ResolucionLicencia { get; set; }
        public string? ResolucionRecepcion { get; set; }
        public string? CodigoOrden { get; set; }
        public string? PartidaParcelaRegistral { get; set; }
        public string? Nota { get; set; }
        public string? Fundo { get; set; }
        public string? SubLote { get; set; }

        public int? IdUsuario { get; set; }
        public string? Ip { get; set; }
        public int? Estado { get; set; }

        public virtual UbigeoDto? Ubigeo { get; set; }
        public virtual TipoHabilitacionUrbanaDto? TipoHabilitacionUrbana { get; set; }
    }
}
