using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.Admins.Cargos;

namespace Jca.Sigmuni.Application.Services.Admins.Abstractions
{
    public interface ICargoService : IServiceCrud<CargoDto, CargoFormDto, int>, IServicePaginated<CargoDto>
    {
    }
}
