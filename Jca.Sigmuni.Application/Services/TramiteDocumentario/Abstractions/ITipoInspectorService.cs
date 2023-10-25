using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoInspectors;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions
{
    public interface ITipoInspectorService
    {
        Task<IList<TipoInspectorDto>> FindAll();

    }
}
