using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Domain.General
{
    public class EstadoAcabado
    {
        public int IdEstadoAcabado { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual ICollection<MonumentoColonial> MonumentoColonialCimiento { get; set; }
        public virtual ICollection<MonumentoColonial> MonumentoColonialMuro { get; set; }
        public virtual ICollection<MonumentoColonial> MonumentoColonialPiso { get; set; }
        public virtual ICollection<MonumentoColonial> MonumentoColonialTecho { get; set; }
        public virtual ICollection<MonumentoColonial> MonumentoColonialPilastra { get; set; }
        public virtual ICollection<MonumentoColonial> MonumentoColonialRevestimiento { get; set; }
        public virtual ICollection<MonumentoColonial> MonumentoColonialBalcon { get; set; }
        public virtual ICollection<MonumentoColonial> MonumentoColonialPuerta { get; set; }
        public virtual ICollection<MonumentoColonial> MonumentoColonialVentana { get; set; }
        public virtual ICollection<MonumentoColonial> MonumentoColonialReja { get; set; }
        public virtual ICollection<MonumentoColonial> MonumentoColonialOtro { get; set; }
    }
}
