namespace Jca.Sigmuni.Domain.Admins
{
    public class Cargo 
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }

        public virtual ICollection<AreaCargo> AreaCargos { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
