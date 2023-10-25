using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoDocumentoSimples;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions
{
    public interface ITipoDocumentoSimpleService
    {
        Task<IList<TipoDocumentoSimpleDto>> FindAll();

    }
}
