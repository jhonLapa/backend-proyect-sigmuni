using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Solicitudes;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions
{
    public interface ISolicitudService:IServiceCrud<SolicitudDto,SolicitudFormDto,int>,IServicePaginated<SolicitudDto>
    {
        Task<SolicitudDto> CrearSolicitudPresencialAsunc(SolicitudFormDto dto);
        Task<SolicitudDto> ObtenerTramiteSolicitudPorIdAsyn(int idSolicitud);
        Task<IList<SolicitudDto>> FindAllInfoDocumento();
        Task<SolicitudDto> ObtenerPorNumeroSolicitud(string numeroSolicitud);
        Task<SolicitudDto> ObtenerUltimoSolicitud();
        Task<ResponsePagination<SolicitudBusquedaDto>> PaginacionSolicitud(RequestPagination<SolicitudBusquedaDto> dto);
        Task<List<SolicitudDto>> ObtenerPorAnioSolicitud(int anio);
    }
}
