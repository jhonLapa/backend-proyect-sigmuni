using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.General.SeccionDocumentals;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface ISeccionDocumentoService : IServiceCrud<SeccionDocumentalDto, SeccionDocumentalFormDto, int>, IServicePaginated<SeccionDocumentalDto>
    {
    }
}
