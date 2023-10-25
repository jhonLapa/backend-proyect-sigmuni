using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class TipoPartidaRegistral
    {
        public int IdTipoPartidaRegistral { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual ICollection<SolicitudCuc> SolicitudCuc { get; set; }
        public virtual ICollection<Sunarp> Sunarps { get; set; }
        //public virtual ICollection<Solicitud> Solicitud { get; set; }
    }
}
