using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.CompendioNormas.NormasInteres;

namespace Jca.Sigmuni.Application.Services.CompendioNormas.Abstractions
{
    public interface INormaInteresService : IServiceCrud<NormaInteresDto, NormaInteresFormDto, int>, IServicePaginated<NormaInteresDto>
    {
        Task<NormaDiaDetalleDto> FindNormaDetalleAsync(int id);
    }
}
