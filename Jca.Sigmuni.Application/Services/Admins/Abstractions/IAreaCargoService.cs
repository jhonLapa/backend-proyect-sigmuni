using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.Admins.AreaCargos;

namespace Jca.Sigmuni.Application.Services.Admins.Abstractions
{
    public interface IAreaCargoService : IServiceCrud<AreaCargoDto, AreaCargoFormDto, int>, IServicePaginated<AreaCargoDto>
    {
    }
}
