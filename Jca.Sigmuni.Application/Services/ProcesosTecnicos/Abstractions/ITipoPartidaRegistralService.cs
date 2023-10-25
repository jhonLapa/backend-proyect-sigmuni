using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoPartidaRegistrales;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ITipoPartidaRegistralService
    {
        Task<IList<TipoPartidaRegistralDto>> FindAll();
    }
}
