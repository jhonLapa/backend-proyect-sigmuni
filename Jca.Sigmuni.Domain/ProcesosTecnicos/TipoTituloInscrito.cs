namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class TipoTituloInscrito
    {
        public int IdTipoTituloInscrito { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual ICollection<Sunarp> Sunarps { get; set; }
    }
}
