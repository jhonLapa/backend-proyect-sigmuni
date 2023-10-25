using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface IFiliacionCronologicaRepository
    {
        Task<IList<FiliacionCronologica>> FindAll();
    }
}
