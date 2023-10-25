using AutoMapper;
using Jca.Sigmuni.Application.Dtos.CompendioNormas.NormasInteres;
using Jca.Sigmuni.Application.Dtos.General.InfoContactos;
using Jca.Sigmuni.Application.Dtos.General.TipoPersonas;
using Jca.Sigmuni.Application.Services.CompendioNormas.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.CompendioNormas;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Repositories.CompendioNormas.Abastractions;
using Jca.Sigmuni.Infraestructure.Repositories.CompendioNormas.Implementations;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.CompendioNormas.Inplementations
{
    public class NormaInteresMenuService : INormaInteresMenuService
    {
        private readonly IMapper _mapper;
        private readonly INormaInteresMenuRepository _normaInteresMenuRepository;

        public NormaInteresMenuService(IMapper mapper, INormaInteresMenuRepository normaInteresMenuRepository)
        {
            _mapper = mapper;
            _normaInteresMenuRepository = normaInteresMenuRepository;
        }

        public async Task<NormaInteresMenuDto> Create(NormaInteresMenuFormDto dto)
        {
            var normaInteresMenu = new NormaInteresMenu();

            normaInteresMenu.IdMenu = dto.IdMenu;
            normaInteresMenu.IdNormaInteres = dto.IdNormaInteres;
            var entity = _mapper.Map<NormaInteresMenu>(normaInteresMenu);
            var response = await _normaInteresMenuRepository.Create(entity);

            return _mapper.Map<NormaInteresMenuDto>(response);
        }
        public async Task<NormaInteresMenuDto?> Disable(int id)
        {
            var response = await _normaInteresMenuRepository.Disable(id);

            return _mapper.Map<NormaInteresMenuDto>(response);
        }
        public async Task<NormaInteresMenuDto?> Edit(int id, NormaInteresMenuFormDto dto)
        {
            var normaInteresMenu = new NormaInteresMenu();

            normaInteresMenu.IdMenu = dto.IdMenu;
            normaInteresMenu.IdNormaInteres = dto.IdNormaInteres;

            var entity = _mapper.Map<NormaInteresMenu>(normaInteresMenu);
            var response = await _normaInteresMenuRepository.Edit(id, entity);

            return _mapper.Map<NormaInteresMenuDto>(response);
        }
        public async Task<NormaInteresMenuDto?> Find(int id)
        {
            var response = await _normaInteresMenuRepository.Find(id);

            return _mapper.Map<NormaInteresMenuDto>(response);
        }
        public async Task<IList<NormaInteresMenuDto>> FindAll()
        {
            var response = await _normaInteresMenuRepository.FindAll();

            return _mapper.Map<IList<NormaInteresMenuDto>>(response);
        }
        public async Task<ResponsePagination<NormaInteresMenuDto>> PaginatedSearch(RequestPagination<NormaInteresMenuDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<NormaInteresMenu>>(dto);
            var response = await _normaInteresMenuRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<NormaInteresMenuDto>>(response);
        }
        public async Task<List<NormaInteresMenuDto>> BuscarPorIdNormaInteres(int id)
        {
            var response = await _normaInteresMenuRepository.BuscarPorIdNormaInteres(id);
            var temporal = 0;

            return _mapper.Map<List<NormaInteresMenuDto>>(response);
        }
    }
}
