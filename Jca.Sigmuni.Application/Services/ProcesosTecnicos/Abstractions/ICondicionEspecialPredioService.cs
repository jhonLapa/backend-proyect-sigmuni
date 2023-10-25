using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesEspecialesPredios;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ICondicionEspecialPredioService
    {
        Task<IList<CondicionEspecialPredioDto>> FindAll();
    }
}
