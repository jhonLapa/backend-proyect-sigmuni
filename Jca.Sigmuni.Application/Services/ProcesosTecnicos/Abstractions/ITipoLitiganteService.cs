using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoLitigantes;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ITipoLitiganteService
    {
        Task<IList<TipoLitiganteDto>> FindAll();
    }
}
