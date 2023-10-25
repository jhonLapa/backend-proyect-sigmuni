using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UnidadMedidas;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoOtrasInstalaciones
{
    public class TipoOtraInstalacionDto
    {
        public int IdTipoOtraInstalacion { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int? IdUnidadMedida { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public bool? Estado { get; set; }

        public virtual UnidadMedidaDto? UnidadMedida { get; set; }
    }
}
