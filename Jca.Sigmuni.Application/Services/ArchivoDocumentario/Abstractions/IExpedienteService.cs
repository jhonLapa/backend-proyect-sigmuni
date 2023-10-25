using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.Expedientes;

namespace Jca.Sigmuni.Application.Services.ArchivoDocumentario.Abstractions
{
    public interface IExpedienteService : IServiceCrud<ExpedienteDto, ExpedienteFormDto, int>, IServicePaginated<ExpedienteDto>
    {
        Task<ExpedienteDto> FindxInfo(int id);
    }
}
