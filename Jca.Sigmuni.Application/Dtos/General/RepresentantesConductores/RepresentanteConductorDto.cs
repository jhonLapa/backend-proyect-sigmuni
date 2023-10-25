using Jca.Sigmuni.Application.Dtos.General.DocumentoIdentidades;
using Jca.Sigmuni.Application.Dtos.General.InfoContactos;

namespace Jca.Sigmuni.Application.Dtos.General.RepresentantesConductores
{
    public class RepresentanteConductorDto
    {
        public int IdPersona { get; set; }
        public string? Nombre { get; set; }
        public string? Paterno { get; set; }
        public string? Materno { get; set; }
        public string? NumeroDni { get; set; }
        public DocumentoIdentidadDto? DocumentoIdentidad { get; set; }
        public InfoContactoDto? Contacto { get; set; }
    }
}
