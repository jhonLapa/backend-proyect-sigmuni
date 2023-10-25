using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.General.Documentos;
using Jca.Sigmuni.Application.Dtos.General.TipoPersonas;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface IDocumentoService : IServiceCrud<DocumentoB64Dto, DocumentoB64FormDto, int>, IServicePaginated<DocumentoB64Dto>
    {
        public Task<DocumentoDto?> FindFullDocument(int id);
    }
}
