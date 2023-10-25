using Jca.Sigmuni.Domain.Incidencias;

namespace Jca.Sigmuni.Domain.General
{
    public class ReportarForma
    {
        public int IdReportarForma { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        public virtual ICollection<Incidencia> Incidencia { get; set; }

    }
}
