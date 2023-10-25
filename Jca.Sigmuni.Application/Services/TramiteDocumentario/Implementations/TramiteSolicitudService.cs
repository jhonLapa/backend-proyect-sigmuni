using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TramiteSolicituds;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations
{
    public class TramiteSolicitudService : ITramiteSolicitudService
    {
        private readonly IMapper _mapper;
        private readonly ITramiteSolicitudRepository _tramiteSolicitudRepository;

        public TramiteSolicitudService(IMapper mapper, ITramiteSolicitudRepository tramiteSolicitudRepository)
        {
            _mapper = mapper;
            _tramiteSolicitudRepository = tramiteSolicitudRepository;
        }

        public async Task<ResponsePagination<TramiteSolicitudDto>> PaginatedSearch(RequestPagination<TramiteSolicitudDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<TramiteSolicitud>>(dto);
            var response =await _tramiteSolicitudRepository.PaginatedSearch(entity);
            return _mapper.Map<ResponsePagination<TramiteSolicitudDto>>(response);
        }
    }
}
