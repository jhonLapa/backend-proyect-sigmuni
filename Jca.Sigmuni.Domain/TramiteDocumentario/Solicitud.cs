using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.Jurisdiccion;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class Solicitud
    {
        public int Id { get; set; }
        public string? NumeroExpediente { get; set; }
        public string? NumeroSolicitud { get; set; }
        public int Inspeccion { get; set; }
        public decimal? Monto { get; set; }
        public string? NumeroRecibo { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }

        public int? IdProcedimiento { get; set; }
        public int? IdSolicitante { get; set; }
        public int? IdRepresentanteLegal { get; set; }

        public int? IdMedioRegistro { get; set; }
        public int? AnioSolicitud { get; set; }
        public int? IdTipoDocumentoSimple { get; set; }

        public int? IdTipoTramite { get; set; }
        public string? NombreDocumento { get; set; }
        public int? IdArea { get; set; }
        public int? IdUsuarioAccion { get; set; }
        public string? NumExpReferencia { get; set; }
        public string? AsuntoDocSimple { get; set; }
        public int? ActualizacionGrafica { get; set; }
        //public string Ip { get; set; }
        public int? NumeroInspeccion { get; set; }
        public int? AnioInspeccion { get; set; }

        public virtual TipoDocumentoSimple? TipoDocumentoSimple { get; set; }
        public virtual Area? Area { get; set; }
        public virtual TipoTramite? TipoTramite { get; set; }
        public virtual MedioRegistro? MedioRegistro { get; set; }
        public virtual Procedimiento? Procedimiento { get; set; }
        public virtual Persona? RepresentanteLegal { get; set; }
        public virtual Persona? Solicitante { get; set; }
        //public virtual TipoPartidaRegistral? TipoPartidaRegistral { get; set; }


        public virtual ICollection<TramiteSolicitud>? TramiteSolicitudes { get; set; }
        //public virtual ICollection<JurisdiccionLote> JurisdiccionLote { get; set; }
        public virtual ICollection<SolicitudCuc>? SolicitudCuc { get; set; }
        //public virtual ICollection<TramiteSolicitud> TramiteSolicitudes { get; set; }
        //public virtual ICollection<SolicitudCuc> SolicitudCuc { get; set; }
        public virtual ICollection<JurisdiccionLote>? JurisdiccionLote { get; set; }
        public virtual ICollection<SolicitudRequisito>? SolicitudRequisitos { get; set; }
        public virtual ICollection<Producto>? Producto { get; set; }
        public virtual ICollection<Pago>? Pagos { get; set; }

        public virtual ICollection<Inspeccion>? Inspecciones { get; set; }

        public virtual ICollection<Actividad>? Actividades { get; set; }
        public virtual ICollection<ActualizacionCartografico>? ActualizacionCartografico { get; set; }

        //public virtual ICollection<InfDocumento> InfDocumento { get; set; }

        //public virtual ICollection<ProductoCarto> ProductoCarto { get; set; }
        public virtual ICollection<ErrorCartograficoSolicitud>? ErrorCartograficoSolicituds { get; set; }

        //public virtual ICollection<CertificadoAdminCarto> CertificadoAdminCarto { get; set; }
        public virtual ICollection<InformeTecnico>? InformeTecnico { get; set; }
        public virtual ICollection<InfDocumento>? InfDocumento { get; set; }


        //public virtual ICollection<SolicitudNotificacion> SolicitudNotificacion { get; set; }
        //public virtual ICollection<InspeccionCuc> InspeccionCuc { get; set; }
        //public virtual ICollection<ReintegroSolicitudes> ReintegroSolicitudes { get; set; }



    }
}
