using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Eccs;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IEccService
    {
        Task<IList<EccDto>> FindAll();
    }
}
