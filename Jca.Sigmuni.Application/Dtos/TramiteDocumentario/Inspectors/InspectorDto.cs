using Jca.Sigmuni.Application.Dtos.General.Personas;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.SupervisorInsps;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoInspectors;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Inspectors
{
    public class InspectorDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int IdTipoInspector { get; set; }
        public int? IdSupervisorInsp { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }
        public string EstadoNombre { get; set; }
        public virtual TipoInspectorDto TipoInspector { get; set; }
        public virtual SupervisorInspDto SupervisorInsp { get; set; }
        public virtual PersonaDto Persona { get; set; }
    }
}
