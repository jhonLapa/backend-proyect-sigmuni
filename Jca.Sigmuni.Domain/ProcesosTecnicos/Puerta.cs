using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.Vias;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class Puerta
    {
        public int IdPuerta { get; set; }
        public string? CodigoPuerta { get; set; }
        public string? NumeracionMunicipal { get; set; }
        public int? IdTipoPuerta { get; set; }
      
        public string? IdVia { get; set; }
        public string? IdLoteCartografia { get; set; }
        public int IdUbicacionPredio { get; set; }
        public int? IdCondNumPrincipal { get; set; }
        public int? IdCondNumSecundario { get; set; }
        public int? IdTipoNumPrincipal { get; set; }
        public int? IdTipoNumSecundario { get; set; }
        public string? LtPrincipal { get; set; }
        public string? LtScundario { get; set; }
        public int? IdUbicacionNumeracion { get; set; }
        public string? NumCertifPrincipal { get; set; }
        public string? NumCertifSecundario { get; set; }
        public int? AnioPrincipal { get; set; }
        public int? AnioSecundario { get; set; }
        public string? NumeroInterior { get; set; }
        public int? IdTipoInterior { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual TipoPuerta TipoPuerta { get; set; }
        public virtual Via Via { get; set; }
        public virtual UbicacionPredio UbicacionPredio { get; set; }
        public virtual CondicionNumeracion CondicionNumeracion { get; set; }
        //public virtual CondicionNumeracion CondicionNumeracion2 { get; set; }
        //public virtual TipoNumeracion TipoNumeracion { get; set; }
        //public virtual TipoNumeracion TipoNumeracion2 { get; set; }
        //public virtual UbicacionNumeraciones UbicacionNumeracion { get; set; }
        public virtual TipoInterior TipoInterior { get; set; }
        public virtual ICollection<Domicilio> Domicilio { get; set; }
    }
}
