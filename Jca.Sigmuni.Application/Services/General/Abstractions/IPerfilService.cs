using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.General.Perfiles;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface IPerfilService : IServiceCrud<PerfilDto, PerfilFormDto, int>, IServicePaginated<PerfilDto>
    {
    }
}
