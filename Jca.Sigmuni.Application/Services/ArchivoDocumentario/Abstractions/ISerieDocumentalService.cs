using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.SerieDocumental;

namespace Jca.Sigmuni.Application.Services.ArchivoDocumentario.Abstractions
{
    public interface ISerieDocumentalService : IServiceCrud<SerieDocumentalDto, SerieDocumentalFormDto, int>, IServicePaginated<SerieDocumentalDto>
    {
    }
}
