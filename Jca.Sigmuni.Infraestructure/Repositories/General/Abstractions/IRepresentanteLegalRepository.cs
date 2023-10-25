using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface IRepresentanteLegalRepository : IRepositoryCrud<RepresentanteLegal, int>, IRepositoryPaginated<RepresentanteLegal>
    {
    }
}
