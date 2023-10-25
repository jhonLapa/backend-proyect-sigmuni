using AutoMapper;
using Jca.Sigmuni.Application.Dtos.Vias.Vias;
using Jca.Sigmuni.Application.Services.Vias.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Vias;
using Jca.Sigmuni.Infraestructure.Repositories.Vias.Abstractions;

namespace Jca.Sigmuni.Application.Services.Vias.Implementations
{
    public class ViaService : IViaService
    {

        private readonly IMapper _mapper;
        private readonly IViaRepository _ViaRepository;

        public ViaService(IMapper mapper, IViaRepository ViaRepository)
        {
            _mapper = mapper;
            _ViaRepository = ViaRepository;
        }
        public async Task<IList<ViaDto>> FindAll()
        {
            var response = await _ViaRepository.FindAll();

            return _mapper.Map<IList<ViaDto>>(response);
        }

        public async Task<ResponsePagination<ViaDto>> PaginatedSearch(RequestPagination<ViaBusquedaDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<Via>>(dto);
            var response = await _ViaRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<ViaDto>>(response);
        }

    }
}
