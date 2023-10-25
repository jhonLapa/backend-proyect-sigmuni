namespace Jca.Sigmuni.Domain.General
{
    public class CategoriaOrganizacion
    {
        public int IdCategoriaOrganizacion { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public int? IdTipoPersona { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual TipoPersona TipoPersona { get; set; }

        public virtual ICollection<Persona> Persona { get; set; }
    }
}
