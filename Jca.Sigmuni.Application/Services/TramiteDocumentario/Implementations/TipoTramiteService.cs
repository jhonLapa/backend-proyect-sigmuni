using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Autoridades;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoTramites;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations
{
    public class TipoTramiteService : ITipoTramiteService
    {
        private readonly IMapper _mapper;
        private readonly ITipoTramiteRepository _tipoTramiteRepository;

        public TipoTramiteService(IMapper mapper, ITipoTramiteRepository tipoTramiteRepository)
        {
            _mapper = mapper;
            _tipoTramiteRepository = tipoTramiteRepository;
        }

        public async Task<IList<TipoTramiteDto>> findAll()
        {
            var response = await _tipoTramiteRepository.FindAll();

            return _mapper.Map<IList<TipoTramiteDto>>(response);
        }
    }
}
