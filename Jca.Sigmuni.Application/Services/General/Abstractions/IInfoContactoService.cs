using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.General.InfoContactos;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface IInfoContactoService : IServiceCrud<InfoContactoDto, InfoContactoFormDto, int>, IServicePaginated<InfoContactoDto>
    {
        Task<InfoContactoDto> CrearInfoContacto(InfoContactoDto entity, int idPersona, int? idTipoPersona);
    }
}
