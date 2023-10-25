using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesTitulares;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ICondicionTitularService
    {
        Task<IList<CondicionTitularDto>> FindAll();
    }
}
