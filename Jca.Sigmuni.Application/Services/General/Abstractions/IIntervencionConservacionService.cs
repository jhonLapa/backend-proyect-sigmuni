using Jca.Sigmuni.Application.Dtos.General.IntervencionesConservaciones;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface IIntervencionConservacionService
    {
        Task<IList<IntervencionConservacionDto>> FindAll();
    }
}
