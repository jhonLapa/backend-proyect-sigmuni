using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Autoridades;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoActividades;
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
    public class TipoActividadService : ITipoActividadService
    {
        private readonly IMapper _mapper;
        private readonly ITipoActiviadadRepository _tipoActividadRepository;

        public TipoActividadService(IMapper mapper, ITipoActiviadadRepository tipoActividadRepository)
        {
            _mapper = mapper;
            _tipoActividadRepository = tipoActividadRepository;
        }

        public async Task<IList<TipoActividadDto>> findAll()
        {
            var response = await _tipoActividadRepository.FindAll();

            return _mapper.Map<IList<TipoActividadDto>>(response);
        }
    }
}
