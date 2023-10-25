using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.AcccionesGenerar;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Autoridades;
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
    public class AccionGenerarService : IAccionGenerarService
    {
        private readonly IMapper _mapper;
        private readonly IAccionGenerarRepository _accionGenerarRepository;

        public AccionGenerarService(IMapper mapper, IAccionGenerarRepository accionGenerarRepository)
        {
            _mapper = mapper;
            _accionGenerarRepository = accionGenerarRepository;
        }

        public async Task<IList<AccionGenerarDto>> findAll()
        {
            var response = await _accionGenerarRepository.FindAll();

            return _mapper.Map<IList<AccionGenerarDto>>(response);
        }
    }
}
