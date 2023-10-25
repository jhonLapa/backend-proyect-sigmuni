using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface IOtraInstalacionRepository : IRepositoryBase<OtraInstalacion, int>
    {
        Task<List<OtraInstalacion>> ListarPorIdFichaAsync(int idFicha);
        Task<bool> EliminarAsync(int id);
    }
}
