using Jca.Sigmuni.Application.Dtos.Admins.Domicilios;
using Jca.Sigmuni.Application.Dtos.General.Personas;
using Jca.Sigmuni.Application.Dtos.General.TblCodigos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Procedimientos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.SolicitudCucs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.InformeTecnicos
{
    public class DatosSolicitudDto
    {
        public int Id { get; set; }
        public string? NumeroExpediente { get; set; }
        public string? NumeroSolicitud { get; set; }
        public decimal? Monto { get; set; }
        public string? NumeroRecibo { get; set; }
        //public TipoInformeDto TipoInforme { get; set; }
        public DateTime? FechaReciboReg { get; set; }
        public string? FechaRecibo
        {
            get
            {
                if (FechaReciboReg.HasValue)
                {
                    return Convert.ToDateTime(FechaReciboReg).ToString("dd-MM-yyyy");
                }
                return null;
            }
        }
        public ProcedimientoDto? Procedimiento { get; set; }
        public PersonaDto? Solicitante { get; set; }
        public PersonaDto? RepresentanteLegal { get; set; }

        public List<SolicitudCucDto>? SolicitudCuc { get; set; }
        public string? IdLoteCarto { get; set; }
        public TblCodigoCatastralDto? CodigoCatastral { get; set; }
        //Informe Técnico
        public object? InformeTecnicoJson { get; set; }
        public string? JsonStringInformeTecnico { get; set; }
        public string? NumCorrelativoInformeTec { get; set; }

        //Informe Observacion
        public object? InformeObsJson { get; set; }
        public string? JsonStringInformeObs { get; set; }
        public string? NumCorrelativoInformeObs { get; set; }

        //Informe Improcedencia
        public object? InformeImproJson { get; set; }
        public string? JsonStringInformeImpro { get; set; }
        public string? NumCorrelativoInformeImpro { get; set; }

        //Informe Abandono
        public object? InformeAbandonoJson { get; set; }
        public string? JsonStringInformeAbandono { get; set; }
        public string? NumCorrelativoInformeAbandono { get; set; }

        //Informe Otros
        public object? InformeOtrosJson { get; set; }
        public string? JsonStringInformeOtros { get; set; }
        public string? NumCorrelativoInformeOtros { get; set; }

        public string? TipoVia { get; set; }
        public string? NombreVia { get; set; }
        public string? NumeroExterior { get; set; }
        public string? NumeroInterior { get; set; }
        public string? Ubigeo { get; set; }
        public string? PartidaRegistral { get; set; }
        public string? LoteUrbano { get; set; }
        public string? ManzanaUrbana { get; set; }
    }
}
