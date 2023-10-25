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
    public interface IProcedimientoRepository :IRepositoryCrud<Procedimiento,int>,IRepositoryPaginated<Procedimiento>
    {
        Task<IList<Procedimiento>> FindTramite(int idTipoTramite);
        Task<Procedimiento> ObtenerUltimoProcedimiento();
        Task<ResponsePagination<Procedimiento>> PaginatedSearchFiltros(RequestPagination<Procedimiento> entity,string? fechaRegistroDesde, string? fechaRegistroHasta);
    }
}
