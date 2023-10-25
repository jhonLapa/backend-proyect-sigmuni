using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class Inspeccion
    {
        public int Id { get; set; }
        public DateTime? FechaAsignacion { get; set; }
        public DateTime? Fecha { get; set; }
        //public string HoraInicio { get; set; }
        //public string HoraFin { get; set; }
        public DateTime? FechaCulminacion { get; set; }
        public int? IdMotivo { get; set; }
        public int IdSolicitud { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public int? IdTurno { get; set; }
        public int? IdInspector { get; set; }
        public int? Flag { get; set; }
        public int? IdUsuario { get; set; }
        public string TipoInspector { get; set; }
        public int TipoInspeccion { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }

        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        public virtual Motivo Motivo { get; set; }
        public virtual Solicitud Solicitud { get; set; }
        public virtual TurnoInspeccion TurnoInspeccion { get; set; }
        public virtual Inspector Inspector { get; set; }
    }
}
