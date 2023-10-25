using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ecss;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IEcsService
    {
        Task<IList<EcsDto>> FindAll();
    }
}
