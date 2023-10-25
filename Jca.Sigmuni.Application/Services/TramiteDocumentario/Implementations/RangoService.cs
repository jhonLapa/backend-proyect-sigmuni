using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Autoridades;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Rangos;
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
    public class RangoService : IRangoService
    {
        private readonly IMapper _mapper;
        private readonly IRangoRepository _rangoRepository;

        public RangoService(IMapper mapper, IRangoRepository rangoRepository)
        {
            _mapper = mapper;
            _rangoRepository = rangoRepository;
        }

        public async Task<IList<RangoDto>> findAll()
        {
            var response = await _rangoRepository.findAll();

            return _mapper.Map<IList<RangoDto>>(response);
        }
    }
}
