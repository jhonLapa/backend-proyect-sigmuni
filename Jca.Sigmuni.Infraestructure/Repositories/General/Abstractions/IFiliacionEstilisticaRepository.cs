using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface IFiliacionEstilisticaRepository
    {

        Task<IList<FiliacionEstilistica>> FindAll();
    }
}
