using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Infraestructure.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.Admins.Abastractions
{
    public interface ICargoRepository : IRepositoryCrud<Cargo, int>, IRepositoryPaginated<Cargo>
    {
    }
}
