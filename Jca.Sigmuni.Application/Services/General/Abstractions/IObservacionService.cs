using Jca.Sigmuni.Application.Dtos.General.Observaciones;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface IObservacionService
    {
        Task<IList<ObservacionDto>> FindAll();
    }
}
