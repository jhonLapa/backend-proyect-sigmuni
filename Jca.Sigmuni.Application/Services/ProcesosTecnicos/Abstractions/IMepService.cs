using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Meps;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IMepService
    {
        Task<IList<MepDto>> FindAll();
    }
}
