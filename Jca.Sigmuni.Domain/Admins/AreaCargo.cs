using Jca.Sigmuni.Domain.Base;

namespace Jca.Sigmuni.Domain.Admins
{
    public class AreaCargo
    {
        public int Id { get; set; }
        public bool? Estado { get; set; } = true;
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        public int? IdCargo { get; set; }
        public int? IdArea { get; set; }

        public virtual Cargo Cargo { get; set; }
        public virtual Area Area { get; set; }
    }
}
