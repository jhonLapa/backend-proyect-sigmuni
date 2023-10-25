using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.Admins.Domicilios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.DomicilioConductores;

namespace Jca.Sigmuni.Application.Services.Admins.Abstractions
{
    public interface IDomicilioService : IServiceCrud<DomicilioDto, DomicilioFormDto, int>, IServicePaginated<DomicilioDto>
    {
        Task<int> CrearOActualizarDomicilioConductorAsync(DomicilioConductorDto peticion);
        Task<DomicilioDto> CrearDomicilo(DomicilioDto entity, int idPersona);
        Task<DomicilioDto>ObtenerPorIdPersonaAsync(int idPersona);
    }
}
