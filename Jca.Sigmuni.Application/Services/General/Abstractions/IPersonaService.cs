using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.General.Personas;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface IPersonaService : IServiceCrud<PersonaDto, PersonaFormDto, int>, IServicePaginated<PersonaDto>
    {
        Task<bool> EditPersona(int id, PersonaFormDto requestDto);
        Task<PersonaDto> CrearPersona(PersonaFormDto entity);
        Task<bool> BusquedaPersonaPorNumDoc(string numeroDoc);
        Task<bool> BusquedaPersonaPorNumRuc(string numeroRuc);
    }
}
