using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface IIntervencionInmueblesRepository
    {
        Task<IList<IntervencionInmueble>> FindAll();
    }
}
