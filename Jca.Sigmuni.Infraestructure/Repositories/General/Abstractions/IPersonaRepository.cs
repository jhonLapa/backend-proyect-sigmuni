using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface IPersonaRepository : IRepositoryCrud<Persona, int>, IRepositoryPaginated<Persona>
    {
        Task<bool?> EditPersona(Persona entity);
        Task<bool> BusquedaPersonaPorNumDoc(string numeroDoc);
        Task<bool> BusquedaPersonaPorNumRuc(string numeroRuc);
    }
}
