using Jca.Sigmuni.Application.Dtos.General.IntervencionInmuebles;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface IIntervencionInmueblesService
    {
        Task<IList<IntervencionInmuebleDto>> FindAll();
    }
}
