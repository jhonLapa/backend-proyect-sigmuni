using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.Manzanas;
using Jca.Sigmuni.Application.Dtos.General.Sectores;
using Jca.Sigmuni.Application.Dtos.General.Ubigeos;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class ManzanaService : IManzanaService
    {
        private readonly IMapper _mapper;
        private readonly IManzanaRepository _manzanaRepository;

        public ManzanaService(IMapper mapper, IManzanaRepository manzanaRepository)
        {
            _mapper = mapper;
            _manzanaRepository = manzanaRepository;
        }
        public async Task<IList<ManzanaDto>> FindAll()
        {
            var response = await _manzanaRepository.FindAll();

            return _mapper.Map<IList<ManzanaDto>>(response);
        }

        public async Task<ManzanaDto?> Find(string id)
        {
            var response = await _manzanaRepository.Find(id);

            return _mapper.Map<ManzanaDto>(response);
        }

        public async Task<ResponsePagination<ManzanaDto>> PaginatedSearch(RequestPagination<ManzanaBusquedaDto> dto)
        {
            var lfdto = new RequestPagination<ManzanaDto>()
            {
                Page = dto.Page,
                PerPage = dto.PerPage,
            };
            if (dto.Filter != null)
            {
                lfdto.Filter = new ManzanaDto()
                {
                    Codigo = dto.Filter?.CodigoManzana,
                    Sector = new SectorDto() { Codigo = dto.Filter?.CodigoSector, Ubigeo = new UbigeoDto() { Codigo = dto.Filter?.CodigoUbigeo } } 
                };
            }

            var entity = _mapper.Map<RequestPagination<Manzana>>(lfdto);
            var response = await _manzanaRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<ManzanaDto>>(response);
        }
    }
}
