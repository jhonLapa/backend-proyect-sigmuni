using AutoMapper;
using Jca.Sigmuni.Application.Dtos.Admins.Area;
using Jca.Sigmuni.Application.Services.Admins.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Infraestructure.Repositories.Admins.Abastractions;

namespace Jca.Sigmuni.Application.Services.Admins.Inplementations
{
    public class AreaService : IAreaService
    {
        private readonly IMapper _mapper;
        private readonly IAreaRepository _areaRepository;

        public AreaService(IMapper mapper, IAreaRepository areaRepository)
        {
            _mapper = mapper;
            _areaRepository = areaRepository;
        }

        public async Task<AreaDto> Create(AreaFormDto dto)
        {

            var entity = _mapper.Map<Area>(dto);
            var response = await _areaRepository.Create(entity);

            return _mapper.Map<AreaDto>(response);

        }

        public async Task<AreaDto?> Disable(int id)
        {
            var response = await _areaRepository.Disable(id);

            return _mapper.Map<AreaDto>(response);
        }

        public async Task<AreaDto?> Edit(int id, AreaFormDto dto)
        {
            var entity = _mapper.Map<Area>(dto);
            var response = await _areaRepository.Edit(id, entity);

            return _mapper.Map<AreaDto>(response);
        }

        public async Task<AreaDto?> Find(int id)
        {
            var response = await _areaRepository.Find(id);

            return _mapper.Map<AreaDto>(response);
        }

        public async Task<IList<AreaDto>> FindAll()
        {
            var response = await _areaRepository.FindAll();

            return _mapper.Map<IList<AreaDto>>(response);
        }

        public async Task<ResponsePagination<AreaDto>> PaginatedSearch(RequestPagination<AreaDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<Area>>(dto);
            var response = await _areaRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<AreaDto>>(response);
        }

        public async Task<IList<AreaDto>> SelectAll()
        {
            var response = await _areaRepository.SelectAll();

            return _mapper.Map<IList<AreaDto>>(response);
        }

        public async Task<ResponsePagination<AreaDto>> SelectPaginatedSearch(RequestPagination<AreaDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<Area>>(dto);
            var response = await _areaRepository.SelectPaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<AreaDto>>(response);
        }
    }

}
