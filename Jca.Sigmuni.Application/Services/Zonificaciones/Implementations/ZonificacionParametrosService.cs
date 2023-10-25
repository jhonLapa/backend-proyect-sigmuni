using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.Lotes;
using Jca.Sigmuni.Application.Dtos.Zonificaciones.ZonificacionesParametros;
using Jca.Sigmuni.Application.Services.Zonificaciones.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Zonificaciones;
using Jca.Sigmuni.Infraestructure.Repositories.Zonificaciones.Abstractions;

namespace Jca.Sigmuni.Application.Services.Zonificaciones.Implementations
{
    public class ZonificacionParametrosService : IZonificacionParametrosService
    {

        private readonly IMapper _mapper;
        private readonly IZonificacionRepository _zonificacionRepository;

        public ZonificacionParametrosService(IMapper mapper, IZonificacionRepository ZonificacionRepository)
        {
            _mapper = mapper;
            _zonificacionRepository = ZonificacionRepository;
        }
        public async Task<IList<ZonificacionParametroDto>> FindAll()
        {
            var response = await _zonificacionRepository.FindAll();

            return _mapper.Map<IList<ZonificacionParametroDto>>(response);
        }

        public async Task<ResponsePagination<ZonificacionParametroDto>> PaginatedSearch(RequestPagination<ZonificacionParametroDto> dto)
        {
            var lfdto = new RequestPagination<ZonificacionParametroDto>()
            {
                Page = dto.Page,
                PerPage = dto.PerPage,
                Filter = dto.Filter,
            };
            var entity = _mapper.Map<RequestPagination<ZonificacionParametro>>(lfdto);
            var response = await _zonificacionRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<ZonificacionParametroDto>>(response);
        }

    }
}
