using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface IAfectacionAntropicaRepository
    {
        Task<IList<AfectacionAntropica>> FindAll();
    }
}
