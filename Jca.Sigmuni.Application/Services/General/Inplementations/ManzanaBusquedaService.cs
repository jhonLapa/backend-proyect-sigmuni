using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.Manzanas;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class ManzanaBusquedaService : IManzanaBusquedaService
    {
        private readonly IMapper _mapper;
        private readonly IManzanaBusquedaRepository _manzanaBusquedaRepository;

        public ManzanaBusquedaService(IMapper mapper, IManzanaBusquedaRepository manzanaBusquedaRepository)
        {
            _mapper = mapper;
            _manzanaBusquedaRepository = manzanaBusquedaRepository;
        }
        public async Task<IList<ManzanaDto>> FindAll()
        {
            var response = await _manzanaBusquedaRepository.FindAll();

            return _mapper.Map<IList<ManzanaDto>>(response);
        }

        public async Task<ResponsePagination<ManzanaDto>> PaginatedSearch(RequestPagination<ManzanaDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<Manzana>>(dto);
            var response = await _manzanaBusquedaRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<ManzanaDto>>(response);
        }
    }
}
