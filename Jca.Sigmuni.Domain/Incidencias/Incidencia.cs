using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Domain.Incidencias
{
    public class Incidencia
    {
        public int IdIncidencia { get; set; }
        public string NumeroIncidencia { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Descripcion { get; set; }
        public int IdTipoIncidencia { get; set; }
        public string SolucionPrevia { get; set; }
        public int? IdPersona { get; set; }
        public int? IdReportarForma { get; set; }
        public int? IdArea { get; set; }
        public int? IdDocumento { get; set; }
        public int? IdMotivo { get; set; }
        public string OtroMotivo { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public int? IdPersonaInvolucrada { get; set; }
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }

        public virtual TipoIncidencia TipoIncidencia { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual ReportarForma ReportarForma { get; set; }
        public virtual Area Area { get; set; }
        public virtual Documento Documento { get; set; }
        public virtual Motivo Motivo { get; set; }
        public virtual Persona PersonaInvolucrada { get; set; }
        //public virtual ICollection<Notificacion> Notificacion { get; set; }
        //public virtual ICollection<AccionIncidencia> AccionIncidencia { get; set; }

    }
}
