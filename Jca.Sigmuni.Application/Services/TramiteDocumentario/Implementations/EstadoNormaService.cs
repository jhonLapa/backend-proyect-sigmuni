using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.EstadoNormas;
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
    public class EstadoNormaService:IEstadoNormaService
    {
        private readonly IMapper _mapper;
        private readonly IEstadoNormaRepository _estadoNormaRepository;

        public EstadoNormaService(IMapper mapper, IEstadoNormaRepository estadoNormaRepository)
        {
            _mapper = mapper;
            _estadoNormaRepository = estadoNormaRepository;
        }

        public async Task<IList<EstadoNormaDto>> findAll()
        {
            var response = await _estadoNormaRepository.FindAll();

            return _mapper.Map<IList<EstadoNormaDto>>(response);
        }
    }
}
