using Jca.Sigmuni.Domain.Base;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class TipoAnuncio //: ModelBase<int>
    {
        public int IdTipoAnuncio { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual ICollection<AutorizacionAnuncio> AutorizacionAnuncios { get; set; }
    }
}
