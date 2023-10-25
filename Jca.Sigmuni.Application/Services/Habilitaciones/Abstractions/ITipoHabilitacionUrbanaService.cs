using Jca.Sigmuni.Application.Dtos.Habilitaciones.TipoHabilitacionesUrbanas;

namespace Jca.Sigmuni.Application.Services.Habilitaciones.Abstractions
{
    public interface ITipoHabilitacionUrbanaService
    {
        Task<IList<TipoHabilitacionUrbanaDto>> FindAll();
    }
}
