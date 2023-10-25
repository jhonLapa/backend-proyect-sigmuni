using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface ITipoOtraInstalacionRepository
    {
        Task<IList<TipoOtraInstalacion>> FindAll();
        Task<TipoOtraInstalacion?> BuscarPorCodigoAsync(string codigo);
    }
}
