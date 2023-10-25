using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.Sectores;
using Jca.Sigmuni.Application.Dtos.General.Ubigeos;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class SectorService : ISectorService
    {
        private readonly IMapper _mapper;
        private readonly ISectorRepository _sectorRepository;

        public SectorService(IMapper mapper, ISectorRepository sectorRepository)
        {
            _mapper = mapper;
            _sectorRepository = sectorRepository;
        }
       

        public async Task<ResponsePagination<SectorDto>> PaginatedSearch(RequestPagination<SectorDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<Sector>>(dto);
            var response = await _sectorRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<SectorDto>>(response);
        }
    }
}
