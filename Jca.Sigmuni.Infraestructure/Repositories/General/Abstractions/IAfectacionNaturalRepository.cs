using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface IAfectacionNaturalRepository
    {
        Task<IList<AfectacionNatural>> FindAll();
    }
}
