using Jca.Sigmuni.Application.Dtos.Admins.Area;
using Jca.Sigmuni.Application.Dtos.General.Personas;
using Jca.Sigmuni.Application.Dtos.General.RepresentantesLegales;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Inspecciones;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.MedioRegistros;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Pagos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Procedimientos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.SolicitudCucs;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.SolicitudRequisitos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoDocumentoSimples;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoTramites;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Solicitudes
{
    public class SolicitudDto
    {
        public int Id { get; set; }
        public string? NumeroExpediente { get; set; }
        public string? NumeroSolicitud { get; set; }
        public int? Inspeccion { get; set; }
        public decimal? Monto { get; set; }
        public string? NumeroRecibo { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaReciboDesde { get; set; }
        public DateTime? FechaReciboHasta { get; set; }
        public bool? Estado { get; set; }
        public string? EstadoNombre { get; set; }

        public int? IdProcedimiento { get; set; }
        public int? IdSolicitante { get; set; }
        public int? IdRepresentanteLegal { get; set; }
        public string? CartaPoderRepresentate { get; set; }

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

        public TipoDocumentoSimpleDto? TipoDocumentoSimple { get; set; }
        public  PagoDto? Pago { get; set; }
        public List<PagoDto>? Pagos { get; set; }
        public virtual AreaDto? Area { get; set; }
        public virtual TipoTramiteDto? TipoTramite { get; set; }
        public virtual MedioRegistroDto? MedioRegistro { get; set; }
        public virtual ProcedimientoDto? Procedimiento { get; set; }
        public virtual PersonaSolicitudDto? RepresentanteLegal { get; set; }
        public virtual PersonaSolicitudDto? Solicitante { get; set; }
        public List<SolicitudCucDto>? SolicitudCuc { get; set; }
        public virtual SolicitudRequisitoDto? SolicitudRequisito { get; set; }
        public  List<SolicitudRequisitoDto>? SolicitudRequisitos { get; set; }
        public virtual InspeccionDto? Inspecciones { get; set; }

    }
}
