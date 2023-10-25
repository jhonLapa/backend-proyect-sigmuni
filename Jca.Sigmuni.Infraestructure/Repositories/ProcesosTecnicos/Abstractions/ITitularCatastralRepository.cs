using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface ITitularCatastralRepository : IRepositoryCrud<TitularCatastral, int>
    {
        Task<TitularCatastral?> BuscarPorIdFichaYIdCaracteristicaTitularidadAsync(int idFicha, int? idCaracteristicaTitularidad);
        Task<bool> EliminarAsync(int id);
        Task<TitularCatastral> BuscarPorIdAsync(int id);
    }
}
