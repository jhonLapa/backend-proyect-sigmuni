using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.SolicitudRequisitos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions
{
    public interface ISolicitudRequisitoService
    {
        Task<bool> ActualizarRevisionRequisitoPresentadoAsync(int idSolicitudRequisito,string revision);
        Task<SolicitudRequisitoDto> EliminarDocumentoSolicitudRequisito(int idSolicitudRequisito);
    }
}
