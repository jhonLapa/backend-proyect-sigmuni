using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoInformes;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions
{
    public interface ITipoInformeService
    {
        Task<IList<TipoInformeDto>> FindAll();

    }
}
