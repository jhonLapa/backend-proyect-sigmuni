using Jca.Sigmuni.Application.Dtos.General.Personas;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.SupervisorInsps
{
    public class SupervisorInspDto
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }
        public string EstadoNombre { get; set; }

        public virtual PersonaDto Persona { get; set; }

    }
}
