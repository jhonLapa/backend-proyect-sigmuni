using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface IElementoArquitectonicoRepository
    {
        Task<IList<ElementoArquitectonico>> FindAll();
    }
}
