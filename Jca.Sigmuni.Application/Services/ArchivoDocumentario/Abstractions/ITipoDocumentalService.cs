using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.TipoDocumental;

namespace Jca.Sigmuni.Application.Services.ArchivoDocumentario.Abstractions
{
    public interface ITipoDocumentalService : IServiceCrud<TipoDocumentalDto, TipoDocumentalFormDto, int>, IServicePaginated<TipoDocumentalDto>
    {
    }
}
