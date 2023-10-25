using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface ITecnicoCatastralRepository : IRepositoryCrud<TecnicoCatastral, int>
    {
        Task<bool> EliminarAsync(int id);
    }
}
