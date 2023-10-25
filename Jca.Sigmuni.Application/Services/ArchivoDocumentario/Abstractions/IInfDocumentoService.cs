using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.InfDocumentos;

namespace Jca.Sigmuni.Application.Services.ArchivoDocumentario.Abstractions
{
    public interface IInfDocumentoService : IServiceCrud<InfDocumentoDto, InfDocumentoFormDto, int>, IServicePaginated<InfDocumentoDto>
    {
        Task<InfDocumentoDto> ObtenerUltimoNumeroInf();
    }
}
