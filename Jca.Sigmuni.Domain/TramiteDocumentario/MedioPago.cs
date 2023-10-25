namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class MedioPago
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        public virtual ICollection<Pago>? Pago { get; set; }
    }
}
