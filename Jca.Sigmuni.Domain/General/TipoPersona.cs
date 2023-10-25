namespace Jca.Sigmuni.Domain.General
{
    public class TipoPersona 
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }

        public virtual ICollection<Persona> Persona { get; set; }
        public virtual ICollection<InfoContacto> InfoContacto { get; set; }
        public virtual ICollection<CategoriaOrganizacion> CategoriaOrganizacion { get; set; }
    }
}
