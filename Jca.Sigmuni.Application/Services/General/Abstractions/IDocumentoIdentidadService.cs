using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.General.DocumentoIdentidades;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface IDocumentoIdentidadService : IServiceCrud<DocumentoIdentidadDto, DocumentoIdentidadFormDto, int>, IServicePaginated<DocumentoIdentidadDto>
    {
    }
}
