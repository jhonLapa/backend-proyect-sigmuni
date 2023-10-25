using System;
namespace Jca.Sigmuni.Infraestructure.Core.Repositories
{
	public interface IRepositoryEditable<T, K>
    {
        Task<T?> Edit(K id, T entity);
        Task<T?> Disable(K id);
    }
}