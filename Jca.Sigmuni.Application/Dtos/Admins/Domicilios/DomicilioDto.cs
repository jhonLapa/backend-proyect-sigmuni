using Jca.Sigmuni.Application.Dtos.General.Ubigeos;
using Jca.Sigmuni.Application.Dtos.Habilitaciones.HabilitacionesUrbanas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Edificaciones;
using Jca.Sigmuni.Application.Dtos.Vias.TipoVias;
using Jca.Sigmuni.Application.Dtos.Vias.Vias;

namespace Jca.Sigmuni.Application.Dtos.Admins.Domicilios
{
    public class DomicilioDto
    {
        public int IdDomicilio { get; set; }
        public string? NumMunicipal { get; set; }
        public string? LtPrincipal { get; set; }
        public string? LtSecundario { get; set; }
        public int? IdTipoInterior { get; set; }
        public string? NumInterior { get; set; }
        public string? LtInterior { get; set; }
        public int? IdEdificacion { get; set; }
        public string? CasillaPostal { get; set; }
        public int? IdTipoVia { get; set; }
        public string? IdVia { get; set; }
        public string? NombreVia { get; set; }
        public string? CodigoUbigeo { get; set; }
        public int? IdTipoHU { get; set; }
        public int? IdHU { get; set; }
        public string? NombreHU { get; set; }
        public int? IdPersona { get; set; }
        public int? IdDenominacionInterior { get; set; }
        public string? IdLoteCarto { get; set; }
        public string? Manzana { get; set; }
        public int? IdPuerta { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }
        public string? EstadoNombre { get; set; }
        public virtual EdificacionDto? Edificacion { get;set; }
        public virtual ViaDto? Via { get; set; }
        public virtual TipoViaDto? TipoVia { get; set; }    
        public virtual HabilitacionUrbanaDto? HabilitacionUrbana { get; set; }
        public virtual UbigeoDto? Ubigeo { get; set; }
    }
}
