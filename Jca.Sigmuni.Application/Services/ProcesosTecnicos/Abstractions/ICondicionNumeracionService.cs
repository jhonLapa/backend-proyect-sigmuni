using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesNumeraciones;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ICondicionNumeracionService
    {
        Task<IList<CondicionNumeracionDto>> FindAll();
    }
}
