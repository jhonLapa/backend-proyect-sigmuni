using Jca.Sigmuni.Application.Dtos.Admins.Users;
using Jca.Sigmuni.Application.Dtos.General.Documentos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Solicitudes;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoInformes;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.InformeTecnicos
{
    public class InformeTecnicoDto
    {
        public int Id { get; set; }
        public string? NumCorrelativo { get; set; }
        public DateTime FechaInforme { get; set; }
        public int Flag { get; set; }
        public int IdSolicitud { get; set; }
        public int IdEspecialista { get; set; }
        public int IdTipoInforme { get; set; }
        public string? JsonDatosSolicitud { get; set; }
        public string? JsonNumeracion { get; set; }
        public string? JsonZonificacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }
        public string? EstadoNombre { get; set; }

        public bool? EsInforme { get; set; }
        public virtual SolicitudDto? Solicitud { get; set; }
        public virtual TipoInformeDto? TipoInforme { get; set; }
        public virtual UsuarioDto? Especialista { get; set; }


        public int IdDocumento { get; set; }

        public DocumentoB64FormDto? DocumentoImagenes { get; set; }

    }
}
