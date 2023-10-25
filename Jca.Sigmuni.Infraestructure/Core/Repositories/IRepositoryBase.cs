using System;
namespace Jca.Sigmuni.Infraestructure.Core.Repositories
{
    public interface IRepositoryBase<T, K>
    {
        Task<T> Create(T entity);
        Task<T?> Find(K id);
        Task<IList<T>> FindAll();
    }
}

