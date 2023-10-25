using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface IPredioCatastralAnRepository
    {
        Task<IList<PredioCatastralAn>> FindAll();
    }
}
