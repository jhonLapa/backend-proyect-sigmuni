using AutoMapper;
using Jca.Sigmuni.Application.Dtos.Admins.AreaCargos;
using Jca.Sigmuni.Application.Services.Admins.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Infraestructure.Repositories.Admins.Abastractions;

namespace Jca.Sigmuni.Application.Services.Admins.Inplementations
{
    public class AreaCargoService : IAreaCargoService
    {
        private readonly IMapper _mapper;
        private readonly IAreaCargoRepository _areaCargoRepository;

        public AreaCargoService(IMapper mapper, IAreaCargoRepository areaCargoRepository)
        {
            _mapper = mapper;
            _areaCargoRepository = areaCargoRepository;
        }

        public async Task<AreaCargoDto> Create(AreaCargoFormDto dto)
        {

            var entity = _mapper.Map<AreaCargo>(dto);
            var response = await _areaCargoRepository.Create(entity);

            return _mapper.Map<AreaCargoDto>(response);

        }

        public async Task<AreaCargoDto?> Disable(int id)
        {
            var response = await _areaCargoRepository.Disable(id);

            return _mapper.Map<AreaCargoDto>(response);
        }

        public async Task<AreaCargoDto?> Edit(int id, AreaCargoFormDto dto)
        {
            var entity = _mapper.Map<AreaCargo>(dto);
            var response = await _areaCargoRepository.Edit(id, entity);

            return _mapper.Map<AreaCargoDto>(response);
        }

        public async Task<AreaCargoDto?> Find(int id)
        {
            var response = await _areaCargoRepository.Find(id);

            return _mapper.Map<AreaCargoDto>(response);
        }

        public async Task<IList<AreaCargoDto>> FindAll()
        {
            var response = await _areaCargoRepository.FindAll();

            return _mapper.Map<IList<AreaCargoDto>>(response);
        }

        public async Task<ResponsePagination<AreaCargoDto>> PaginatedSearch(RequestPagination<AreaCargoDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<AreaCargo>>(dto);
            var response = await _areaCargoRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<AreaCargoDto>>(response);
        }
    }

}
