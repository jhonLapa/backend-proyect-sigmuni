using System;
namespace Jca.Sigmuni.Infraestructure.Core.Repositories
{
	public interface IRepositoryCrud<T, K> : IRepositoryBase<T, K>, IRepositoryEditable<T, K>
    {
	}
}

