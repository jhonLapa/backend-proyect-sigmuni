using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Procedimientos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Requisitos;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.ProcedimientoRequisitos
{
    public class ProcedimientoRequisitoDto
    {
        public int Id { get; set; }
        public int IdProcedimiento { get; set; }
        public int IdRequisito { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }
        public ProcedimientoDto? Procedimiento { get; set; }
        public RequisitoDto? Requisito { get; set; }
    }
}
