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
    public interface IValorObraComplementariaRepository : IRepositoryCrud<ValorObraComplementaria, int>
    {
        Task<ResponsePagination<ValorObraComplementaria>> PaginatedSearch(RequestPagination<ValorObraComplementaria> entity);
        Task<ValorObraComplementaria?> BuscarPorTipoOtrasInstalaciones(int anio, string descripcion, int idTipo, string unidadMedida, decimal valor, int item);
        Task<ValorObraComplementaria?> BuscarPorIdTipoAsync(int idTipo);
    }
}
