using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionConductores;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ICondicionConductorService
    {
        Task<IList<CondicionConductorDto>> FindAll();
    }
}
