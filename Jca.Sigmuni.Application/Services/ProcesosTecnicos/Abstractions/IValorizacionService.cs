using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaBusquedas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Valorizaciones;
using Jca.Sigmuni.Core.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IValorizacionService
    {
        Task<ResponsePagination<ValorizacionBusquedaDto>> PaginatedSearch(RequestPagination<ValorizacionBusquedaDto> request);
        Task<List<ValorizacionBusquedaDto>> ListarPorFiltro(ValorizacionBusquedaDto request);
        Task<ResponsePagination<AnioReporteDto>> ListarAniosValorizacionAsync(RequestPagination<AnioReporteDto> request);
        Task<ValorizacionDetalleDto> ObtenerDetalleValorizacionPorIdFichaAsync(int idFicha);
        Task<List<ValorizacionBusquedaDto>> ListarUnidadesValorizacionReporteAniosAsync(List<AnioReporteDto> peticion);
    }
}
