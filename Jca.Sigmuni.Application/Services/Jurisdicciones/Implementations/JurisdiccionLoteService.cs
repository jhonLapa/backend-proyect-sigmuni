using AutoMapper;
using Jca.Sigmuni.Application.Dtos.Jurisdicciones.JurisdiccionesLotes;
using Jca.Sigmuni.Application.Dtos.Zonificaciones.ZonificacionesParametros;
using Jca.Sigmuni.Application.Services.Jurisdicciones.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Jurisdiccion;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.Jurisdicciones.Abstraccions;

namespace Jca.Sigmuni.Application.Services.Jurisdicciones.Implementations
{
    public class JurisdiccionLoteService : IJurisdiccionLoteService
    {

        private readonly IMapper _mapper;
        private readonly IJurisdiccionLoteRepository _JurisdiccionLoteRepository;
        private readonly ILoteRepository _loteRepository;
        private readonly IUbigeoRepository _ubigeoRepository;

        public JurisdiccionLoteService(IMapper mapper, IJurisdiccionLoteRepository JurisdiccionLoteRepository, ILoteRepository loteRepository,
                              IUbigeoRepository ubigeoRepository)
        {
            _mapper = mapper;
            _JurisdiccionLoteRepository = JurisdiccionLoteRepository;
            _loteRepository = loteRepository;
            _ubigeoRepository = ubigeoRepository;
        }
        public async Task<IList<JurisdiccionLoteDto>> FindAll()
        {
            var response = await _JurisdiccionLoteRepository.FindAll();

            return _mapper.Map<IList<JurisdiccionLoteDto>>(response);
        }

        public async Task<ResponsePagination<JurisdiccionLoteDto>> PaginatedSearch(RequestPagination<JurisdiccionLoteDto> dto)
        {
            

            var lfdto = new RequestPagination<JurisdiccionLoteDto>()
            {
                Page = dto.Page,
                PerPage = dto.PerPage,
                Filter = dto.Filter,
            };
            var entity = _mapper.Map<RequestPagination<JurisdiccionLote>>(lfdto);
            var response = await _JurisdiccionLoteRepository.PaginatedSearch(entity);
            

            return _mapper.Map<ResponsePagination<JurisdiccionLoteDto>>(response);
        }

    }
}
