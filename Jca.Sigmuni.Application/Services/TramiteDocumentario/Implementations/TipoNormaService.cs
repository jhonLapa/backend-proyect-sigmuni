using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ecss;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TIpoNormas;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations
{
    public class TipoNormaService : ITipoNormaService
    {
        private readonly IMapper _mapper;
        private readonly ITipoNormaRepository _tipoNormaRepository;

        public TipoNormaService (IMapper mapper, ITipoNormaRepository tipoNormaRepository)
        {
            _mapper = mapper;
            _tipoNormaRepository = tipoNormaRepository;
        }

        public async Task<IList<TipoNormaDto>> findAll()
        {
            var response = await _tipoNormaRepository.FindAll();

            return _mapper.Map<IList<TipoNormaDto>>(response);
        }
    }
}
