using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions
{
    public interface ISolicitudRepository :IRepositoryCrud<Solicitud,int>,IRepositoryPaginated<Solicitud>   
    {
        Task<Solicitud> BuscarPorNumeroSolicitudAsync(string numeroSolitud, int? anioSolicitud);
        Task<Solicitud> BuscarxNumeroSolicitudCucAsync(string numeroSolicitud);
        Task<List<SolicitudRequisito>> ListarxSolicitudAsync(int idSolicitud);
        Task<Solicitud>ObtenerPorNumeroSolicitud(string numeroSolicitud);
        Task<Solicitud> ObtenerUltimoSolicitud();
        Task<ResponsePagination<SolicitudBusqueda>> PaginatedSearhSolicitud(RequestPagination<SolicitudBusqueda> entity);

        Task<List<Solicitud>> ObtenerPorAnioSolicitud(int anio);
    }
}
