using System;
using AutoMapper;
using Jca.Sigmuni.Application.Dtos.Admins.Roles;
using Jca.Sigmuni.Application.Services.Admins.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Infraestructure.Repositories.Admins.Abastractions;

namespace Jca.Sigmuni.Application.Services.Admins.Inplementations
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;

        public RoleService(IMapper mapper, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task<RoleDto> Create(RoleFormDto dto)
        {

            var entity = _mapper.Map<Role>(dto);
            var response = await _roleRepository.Create(entity);

            return _mapper.Map<RoleDto>(response);

        }

        public async Task<RoleDto?> Disable(int id)
        {
            var response = await _roleRepository.Disable(id);

            return _mapper.Map<RoleDto>(response);
        }

        public async Task<RoleDto?> Edit(int id, RoleFormDto dto)
        {
            var entity = _mapper.Map<Role>(dto);
            var response = await _roleRepository.Edit(id, entity);

            return _mapper.Map<RoleDto>(response);
        }

        public async Task<RoleDto?> Find(int id)
        {
            var response = await _roleRepository.Find(id);

            return _mapper.Map<RoleDto>(response);
        }

        public async Task<IList<RoleDto>> FindAll()
        {
            var response = await _roleRepository.FindAll();

            return _mapper.Map<IList<RoleDto>>(response);
        }

        public async Task<ResponsePagination<RoleDto>> PaginatedSearch(RequestPagination<RoleDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<Role>>(dto);
            var response = await _roleRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<RoleDto>>(response);
        }
    }
}

