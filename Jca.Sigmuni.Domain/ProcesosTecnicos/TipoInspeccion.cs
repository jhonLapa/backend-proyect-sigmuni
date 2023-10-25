using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class TipoInspeccion
    {
        public int IdTipoInspeccion { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual ICollection<SolicitudCuc>? SolicitudCuc { get; set; }
        public virtual ICollection<InfoComplementario> InfoComplementarios { get; set; }
    }
}
