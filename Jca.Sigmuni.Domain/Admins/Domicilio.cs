using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.Habilitaciones;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Domain.Vias;

namespace Jca.Sigmuni.Domain.Admins
{
    public class Domicilio
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
        public int? IdHabilitacionUrbana { get; set; }
        public string? IdVia { get; set; }
        public string? NombreVia { get; set; }
        public string? CodigoUbigeo { get; set; }
        public int? IdTipoHU { get; set; }
        public string? NombreHU { get; set; }
        public int? IdPersona { get; set; }
        public int? IdDenominacionInterior { get; set; }
        public string? IdLoteCarto { get; set; }
        public string? Manzana { get; set; }
        public int? IdPuerta { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => Estado != null && Estado == true ? "Activo" : "Inactivo"; }

        public virtual HabilitacionUrbana? HabilitacionUrbana { get; set; }
        public virtual TipoInterior? TipoInterior { get; set; }
        public virtual Edificacion? Edificacion { get; set; }
        public virtual Via? Via { get; set; }
        public virtual Persona? Persona { get; set; }
        public virtual Ubigeo? Ubigeo { get; set; }
        // public virtual DenominacionInterior DenominacionInterior { get; set; }
        // public virtual TipoVia TipoVia { get; set; }
        // public virtual TipoHabilitacionUrbana TipoHabilitacionUrbana { get; set; }
        public virtual Lote? Lote { get; set; }
        public virtual Puerta? Puerta { get; set; }
        public virtual TipoVia? TipoVia { get; set; }


    }
}
