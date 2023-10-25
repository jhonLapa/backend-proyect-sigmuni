using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.InfoComplementarios;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IInfoComplementarioService : IServiceCrud<InfoComplementarioDto, InfoComplementario, int>, IServicePaginated<InfoComplementarioDto>
    {
        Task<InfoComplementario?> CrearOActualizarAsync(InfoComplementarioDto peticion);
    }
}
