using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface IIntervencionConservacionRepository
    {
        Task<IList<IntervencionConservacion>> FindAll();
    }
}
