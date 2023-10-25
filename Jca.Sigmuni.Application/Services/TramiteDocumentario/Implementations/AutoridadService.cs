using AutoMapper;
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
    public class AutoridadService : IAutoridadService
    {
        private readonly IMapper _mapper;
        private readonly IAutoridadRepository _autoridadRepository;

        public AutoridadService(IMapper mapper, IAutoridadRepository autoridadRepository)
        {
            _mapper = mapper;
            _autoridadRepository = autoridadRepository;
        }

        public async Task<IList<AutoridadDto>> findAll()
        {
            var response = await _autoridadRepository.FindAll();

            return _mapper.Map<IList<AutoridadDto>>(response);
        }
    }
}
