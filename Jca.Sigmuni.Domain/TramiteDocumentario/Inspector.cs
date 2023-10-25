using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class Inspector
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int IdTipoInspector { get; set; }
        public int? IdSupervisorInsp { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }

        public virtual TipoInspector TipoInspector { get; set; }
        public virtual SupervisorInsp SupervisorInsp { get; set; }
        public virtual Persona Persona { get; set; }

        public virtual ICollection<Inspeccion> Inspecciones { get; set; }
        //public virtual ICollection<ProductoCarto> ProductoCarto { get; set; }
        //public virtual ICollection<TecnicoCartografico> TecnicoCartografico { get; set; }
    }
}
