using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface IPredioCatastralEnRepository
    {
        Task<IList<PredioCatastralEn>> FindAll();
    }
}
