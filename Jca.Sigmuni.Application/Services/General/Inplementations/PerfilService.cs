using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.Perfiles;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class PerfilService : IPerfilService
    {
        private readonly IMapper _mapper;
        private readonly IPerfilRepository _perfilRepository;

        public PerfilService(IMapper mapper, IPerfilRepository perfilRepository)
        {
            _mapper = mapper;
            _perfilRepository = perfilRepository;
        }

        public async Task<PerfilDto> Create(PerfilFormDto dto)
        {

            var entity = _mapper.Map<Perfil>(dto);
            var response = await _perfilRepository.Create(entity);

            return _mapper.Map<PerfilDto>(response);

        }

        public async Task<PerfilDto?> Disable(int id)
        {
            var response = await _perfilRepository.Disable(id);

            return _mapper.Map<PerfilDto>(response);
        }

        public async Task<PerfilDto?> Edit(int id, PerfilFormDto dto)
        {
            var entity = _mapper.Map<Perfil>(dto);
            var response = await _perfilRepository.Edit(id, entity);

            return _mapper.Map<PerfilDto>(response);
        }

        public async Task<PerfilDto?> Find(int id)
        {
            var response = await _perfilRepository.Find(id);

            return _mapper.Map<PerfilDto>(response);
        }

        public async Task<IList<PerfilDto>> FindAll()
        {
            var response = await _perfilRepository.FindAll();

            return _mapper.Map<IList<PerfilDto>>(response);
        }

        public async Task<ResponsePagination<PerfilDto>> PaginatedSearch(RequestPagination<PerfilDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<Perfil>>(dto);
            var response = await _perfilRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<PerfilDto>>(response);
        }
    }

}
