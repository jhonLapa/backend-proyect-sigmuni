using AutoMapper;
using Jca.Sigmuni.Application.Dtos.Admins.Users;
using Jca.Sigmuni.Application.Dtos.General.Personas;
using Jca.Sigmuni.Application.Services.Admins.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Core.Security.Services.Abstractions;
using Jca.Sigmuni.Core.Security.Services.Implementations;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Repositories.Admins.Abastractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.Extensions.Configuration;

namespace Jca.Sigmuni.Application.Services.Admins.Inplementations
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _userRepository;
        private readonly IPersonaRepository _personaRepository;
        private readonly ISecurityService _securityService;
        private readonly IConfiguration _configuration;

        public UserService(IMapper mapper, IUsuarioRepository userRepository, IPersonaRepository personaRepository, ISecurityService securityService, IConfiguration configuration)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _personaRepository = personaRepository;
            _securityService = securityService;
            _configuration = configuration;
        }

        public async Task<UsuarioDto> Create(UsuarioCreateDto dto)
        {
            var entity = _mapper.Map<Usuario>(dto);
            var response = await _userRepository.Create(entity);

            return _mapper.Map<UsuarioDto>(response);
        }

        public async Task<UsuarioDto?> Disable(int id)
        {
            var response = await _userRepository.Disable(id);

            return _mapper.Map<UsuarioDto>(response);
        }

        public async Task<UsuarioDto?> Edit(int id, UsuarioEditDto dto)
        {
            var entity = _mapper.Map<Usuario>(dto);
            var response = await _userRepository.Edit(id, entity);

            return _mapper.Map<UsuarioDto>(response);
        }

        public async Task<UsuarioDto?> Find(int id)
        {
            var response = await _userRepository.Find(id);

            return _mapper.Map<UsuarioDto>(response);
        }

        public async Task<IList<UsuarioDto>> FindAll()
        {
            var response = await _userRepository.FindAll();

            return _mapper.Map<IList<UsuarioDto>>(response);
        }

        public async Task<ResponsePagination<UsuarioDto>> PaginatedSearch(RequestPagination<UsuarioDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<Usuario>>(dto);
            var response = await _userRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<UsuarioDto>>(response);
        }


        public async Task<UsuarioTokenDto?> LoginAsync(UsuarioLoginDto dto)
        {
            var response = await _userRepository.LoginAsync(dto.NombreUsuario, dto.Clave);
            var usuario = _mapper.Map<UsuarioTokenDto>(response);

            var jwtSecrectKey = _configuration.GetSection("Security:JwtSecrectKey").Get<string>();
            usuario.Security = _securityService.JwtSecurity(jwtSecrectKey);

            return usuario;
        }
    }
}
