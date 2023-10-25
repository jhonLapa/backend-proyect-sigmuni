using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.Ubigeos;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class UbigeoService : IUbigeoService
    {
        private readonly IMapper _mapper;
        private readonly IUbigeoRepository _ubigeoRepository;

        public UbigeoService(IMapper mapper, IUbigeoRepository ubigeoRepository)
        {
            _mapper = mapper;
            _ubigeoRepository = ubigeoRepository;
        }
        public async Task<IList<UbigeoDto>> FindAll()
        {
            var response = await _ubigeoRepository.FindAll();

            return _mapper.Map<IList<UbigeoDto>>(response);
        }

        public async Task<IList<UbigeoDto>> listarPorCodigo(string codigo)
        {
            var response = await _ubigeoRepository.ListarPorCodigo(codigo);
            return _mapper.Map<IList<UbigeoDto>>(response);
        }

        public async Task<ResponsePagination<UbigeoDto>> PaginatedSearch(RequestPagination<UbigeoDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<Ubigeo>>(dto);
            var response = await _ubigeoRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<UbigeoDto>>(response);
        }
    }
}
