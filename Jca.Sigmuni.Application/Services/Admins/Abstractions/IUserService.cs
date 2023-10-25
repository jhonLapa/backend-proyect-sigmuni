using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.Admins.Users;
using Jca.Sigmuni.Application.Dtos.General.Personas;

namespace Jca.Sigmuni.Application.Services.Admins.Abstractions
{
    public interface IUserService : IServiceBase<UsuarioDto, UsuarioCreateDto, int>, IServiceEditable<UsuarioDto, UsuarioEditDto, int>, IServicePaginated<UsuarioDto>
    {        
        Task<UsuarioTokenDto?> LoginAsync(UsuarioLoginDto dto);
    }
}
