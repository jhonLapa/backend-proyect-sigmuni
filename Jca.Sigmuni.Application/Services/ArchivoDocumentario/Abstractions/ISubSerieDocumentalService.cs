using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.SubSerieDocumental;

namespace Jca.Sigmuni.Application.Services.ArchivoDocumentario.Abstractions
{
    public interface ISubSerieDocumentalService : IServiceCrud<SubSerieDocumentalDto, SubSerieDocumentalFormDto, int>, IServicePaginated<SubSerieDocumentalDto>
    {
    }
}
