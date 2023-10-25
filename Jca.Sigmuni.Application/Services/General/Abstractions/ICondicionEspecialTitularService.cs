using Jca.Sigmuni.Application.Dtos.General.CondicionEspecialTitulares;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface ICondicionEspecialTitularService
    {
        Task<IList<CondicionEspecialTitularDto>> FindAll();
    }
}
