using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface IValorUnitarioRepository : IRepositoryCrud<ValorUnitario, int>
    {
        Task<ResponsePagination<ValorUnitario>> PaginatedSearch(RequestPagination<ValorUnitario> entity);
        Task<ValorUnitario?> BuscarPorClasificacionCategoria(int idClasificacion, int idCategoria, int anio);
    }
}
