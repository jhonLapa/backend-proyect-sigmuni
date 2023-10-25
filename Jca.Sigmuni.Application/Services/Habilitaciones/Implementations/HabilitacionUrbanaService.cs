using AutoMapper;
using Jca.Sigmuni.Application.Dtos.Habilitaciones.HabilitacionesUrbanas;
using Jca.Sigmuni.Application.Services.Habilitaciones.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Habilitaciones;
using Jca.Sigmuni.Infraestructure.Repositories.Habilitaciones.Abstracciones;

namespace Jca.Sigmuni.Application.Services.Habilitaciones.Implementations
{
    public class HabilitacionUrbanaService : IHabilitacionUrbanaService
    {

        private readonly IMapper _mapper;
        private readonly IHabilitacionUrbanaRepository _habilitacionUrbanaRepository;

        public HabilitacionUrbanaService(IMapper mapper, IHabilitacionUrbanaRepository habilitacionUrbanaRepository)
        {
            _mapper = mapper;
            _habilitacionUrbanaRepository = habilitacionUrbanaRepository;
        }
        public async Task<IList<HabilitacionUrbanaDto>> FindAll()
        {
            var response = await _habilitacionUrbanaRepository.FindAll();

            return _mapper.Map<IList<HabilitacionUrbanaDto>>(response);
        }


        public async Task<ResponsePagination<HabilitacionUrbanaDto>> PaginatedSearch(RequestPagination<HabilitacionUrbanaBusquedaDto> dto)
        {

            var entity = _mapper.Map<RequestPagination<HabilitacionUrbana>>(dto);
            var response = await _habilitacionUrbanaRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<HabilitacionUrbanaDto>>(response);
        }
    }
}
