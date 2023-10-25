using Jca.Sigmuni.Application.Dtos.General.ElementosArquitectonicos;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface IElementoArquitectonicoService
    {
        Task<IList<ElementoArquitectonicoDto>> FindAll();
    }
}
