using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.Marcadores;

namespace Jca.Sigmuni.Application.Services.ArchivoDocumentario.Abstractions
{
    public interface IMarcadorService : IServiceCrud<MarcadorDto, MarcadorFormDto, int>, IServicePaginated<MarcadorDto>
    {
    }
}
