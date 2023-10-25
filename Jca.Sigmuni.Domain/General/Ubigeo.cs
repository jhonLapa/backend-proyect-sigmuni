using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.Habilitaciones;
using Jca.Sigmuni.Domain.Jurisdiccion;
using Jca.Sigmuni.Domain.Vias;
using Jca.Sigmuni.Domain.Zonificaciones;

namespace Jca.Sigmuni.Domain.General
{
    public class Ubigeo
    {
        public string Codigo { get; set; }
        public string? CodigoPadre { get; set; }
        public string? CodigoParcial { get; set; }
        public string? Nombre { get; set; }
        public int? Nivel { get; set; }
        public string? NombreCompleto { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }

        public virtual ICollection<Domicilio> Domicilios { get; set; }
        public virtual ICollection<HabilitacionUrbana> HabilitacionesUrbanas { get; set; }
        //public virtual ICollection<Via> Via { get; set; }
        public virtual ICollection<ZonificacionParametro> ZonificacionParametros { get; set; }
        public virtual ICollection<JurisdiccionLote>? JurisdiccionLote { get; set; }
        public virtual ICollection<Sector> Sector { get; set; }
    }
}
