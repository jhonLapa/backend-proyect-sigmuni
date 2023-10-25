namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class TipoServicioBasico
    {
        public int IdTipoServicioBasico { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public string? Grupo { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual ICollection<ServicioBasico> ServicioBasicoLuz { get; set; }
        public virtual ICollection<ServicioBasico> ServicioBasicoAgua { get; set; }
        public virtual ICollection<ServicioBasico> ServicioBasicoTelefono { get; set; }
        public virtual ICollection<ServicioBasico> ServicioBasicoDesague { get; set; }
        public virtual ICollection<ServicioBasico> ServicioBasicoGas { get; set; }
        public virtual ICollection<ServicioBasico> ServicioBasicoInternet { get; set; }
        public virtual ICollection<ServicioBasico> ServicioBasicoCable { get; set; }
    }
}
