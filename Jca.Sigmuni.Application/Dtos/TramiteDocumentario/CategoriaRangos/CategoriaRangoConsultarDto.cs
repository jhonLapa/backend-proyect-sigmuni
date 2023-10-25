using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.ProcedimientoRequisitos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Procedimientos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Requisitos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoTramites;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.CategoriaRangos
{
    public class CategoriaRangoConsultarDto
    {
        public List<CategoriaRangoDto> MontoTramite { get; set; }
        public ProcedimientoDto Asunto { get; set; }
        public List<RequisitoDto>? ArrayRequisitos { get; set; }
        public List<ProcedimientoRequisitoDto>? ArrayProcedimientoRequisitos { get; set; }
        public TipoTramiteDto? tipoTramite { get; set; }
        //public List<CategoriaRangoDto>? arrayPlano { get; set; }

        public int Tipo { get; set; }
        public int Anio { get; set; }
        public bool EsNuevo { get; set; }
        public string PlazoReconsideracionP { get; set; }
        public string PlazoReconsideracionR { get; set; }
        public string PlazoApelacionP { get; set; }
        public string PlazoApelacionR { get; set; }
    }
}
