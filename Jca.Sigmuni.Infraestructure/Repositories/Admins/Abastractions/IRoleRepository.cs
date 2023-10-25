using System;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.Admins.Abastractions
{
	public interface IRoleRepository : IRepositoryCrud<Role, int>, IRepositoryPaginated<Role>
    {
	}
}

