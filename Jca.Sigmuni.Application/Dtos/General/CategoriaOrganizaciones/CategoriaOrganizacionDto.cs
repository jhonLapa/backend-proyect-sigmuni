using Jca.Sigmuni.Application.Dtos.General.TipoPersonas;

namespace Jca.Sigmuni.Application.Dtos.General.CategoriaOrganizaciones
{
    public class CategoriaOrganizacionDto
    {
        public int IdCategoriaOrganizacion { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public int? IdTipoPersona { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public TipoPersonaDto? TipoPersona { get; set; }
    }
}
