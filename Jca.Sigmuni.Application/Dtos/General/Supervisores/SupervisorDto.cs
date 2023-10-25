using Jca.Sigmuni.Application.Dtos.General.Personas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas;

namespace Jca.Sigmuni.Application.Dtos.General.Supervisores
{
    public class SupervisorDto
    {
        public int IdTecnicoCatastral { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdPersona { get; set; }
        public int IdFicha { get; set; }
        public string? Firma { get; set; }
        public bool? TieneFirma { get; set; }
        public virtual PersonaDto Persona { get; set; }
        public virtual FichaDto Ficha { get; set; }
    }
}
