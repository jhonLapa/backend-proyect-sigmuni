using Jca.Sigmuni.Domain.Admins;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class CondicionNumeracion
    {
        public int IdCondicionNumeracion { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual ICollection<Puerta> Puertas { get; set; }
    }
}
