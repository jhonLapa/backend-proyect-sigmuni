using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.General.TipoPersonas;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface ITipoPersonaService : IServiceCrud<TipoPersonaDto, TipoPersonaFormDto, int>, IServicePaginated<TipoPersonaDto>
    {
    }
}
