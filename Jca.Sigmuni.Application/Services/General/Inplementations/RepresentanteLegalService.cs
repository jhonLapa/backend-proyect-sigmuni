using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.RepresentantesLegales;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class RepresentanteLegalService : IRepresentanteLegalService
    {
        private readonly IMapper _mapper;
        private readonly IRepresentanteLegalRepository _representanteLegalRepository;
        public RepresentanteLegalService(IMapper mapper, IRepresentanteLegalRepository representanteLegalRepository)
        {
            _mapper = mapper;
            _representanteLegalRepository = representanteLegalRepository;
        }
        public async Task<RepresentanteLegalDto> Create(RepresentanteLegalFormDto dto)
        {
            var entity = _mapper.Map<RepresentanteLegal>(dto);
            var response = await _representanteLegalRepository.Create(entity);

            return _mapper.Map<RepresentanteLegalDto>(response);
        }

        public async Task<RepresentanteLegalDto?> Disable(int id)
        {
            var response = await _representanteLegalRepository.Disable(id);

            return _mapper.Map<RepresentanteLegalDto>(response);
        }

        public async Task<RepresentanteLegalDto?> Edit(int id, RepresentanteLegalFormDto dto)
        {
            var entity = _mapper.Map<RepresentanteLegal>(dto);
            var response = await _representanteLegalRepository.Edit(id, entity);

            return _mapper.Map<RepresentanteLegalDto>(response);
        }

        public async Task<RepresentanteLegalDto?> Find(int id)
        {
            var response = await _representanteLegalRepository.Find(id);

            return _mapper.Map<RepresentanteLegalDto>(response);
        }

        public async Task<IList<RepresentanteLegalDto>> FindAll()
        {
            var response = await _representanteLegalRepository.FindAll();

            return _mapper.Map<IList<RepresentanteLegalDto>>(response);
        }

        public async Task<ResponsePagination<RepresentanteLegalDto>> PaginatedSearch(RequestPagination<RepresentanteLegalDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<RepresentanteLegal>>(dto);
            var response = await _representanteLegalRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<RepresentanteLegalDto>>(response);
        }
    }
}
