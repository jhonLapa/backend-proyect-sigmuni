using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface ICategoriaInmuebleRepository
    {
        Task<IList<CategoriaInmueble>> FindAll();
    }
}
