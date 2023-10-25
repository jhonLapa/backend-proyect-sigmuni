using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesPer;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ICondicionPerService
    {
        Task<IList<CondicionPerDto>> FindAll();
    }
}
