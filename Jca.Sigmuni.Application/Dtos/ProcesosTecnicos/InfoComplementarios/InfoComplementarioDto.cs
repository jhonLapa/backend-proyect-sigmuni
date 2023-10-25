using Jca.Sigmuni.Application.Dtos.General.Observaciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EstadosLlenados;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoDocumentosFichas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoInspecciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoMantenimientos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.InfoComplementarios
{
    public class InfoComplementarioDto
    {
        public int IdInfoComplementario { get; set; }
        public int? NumHabitantes { get; set; }
        public int? NumFamilias { get; set; }
        public string? Observaciones { get; set; }
        public int? IdObservacion { get; set; }
        public int? IdTipoMantenimiento { get; set; }
        public int? IdEstadoLlenado { get; set; }
        public int IdFicha { get; set; }
        public string? NumComunicacion { get; set; }
        public int? IdTipoInspeccion { get; set; }
        public int? IdMotivo { get; set; }
        public int? IdTipoDocumento { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public ObservacionDto? Observacion { get; set; }
        public TipoMantenimientoDto? TipoMantenimiento { get; set; }
        public EstadoLlenadoDto? EstadoLLenado { get; set; }
        public TipoInspeccionDto? TipoInspeccion { get; set; }
        //public MotivoDto Motivo { get; set; }
        public TipoDocumentoFichaDto? TipoDocPresentado { get; set; }
    }
}
