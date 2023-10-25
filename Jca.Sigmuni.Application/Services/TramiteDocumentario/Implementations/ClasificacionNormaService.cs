using AutoMapper;
using Jca.Sigmuni.Application.Dtos.CompendioNormas.ClasificacionNormas;
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
    public class ClasificacionNormaService : IClasificacionNormaService
    {
        private readonly IMapper _mapper;
        private readonly IClasificacionNormaRepository _clasificacionNormaRepository;

        public ClasificacionNormaService(IMapper mapper, IClasificacionNormaRepository clasificacionNormaRepository)
        {
            _mapper = mapper;
            _clasificacionNormaRepository = clasificacionNormaRepository;
        }

        public async Task<IList<ClasificacionNormaDto>> findAll()
        {
            var response = await _clasificacionNormaRepository.FindAll();

            return _mapper.Map<IList<ClasificacionNormaDto>>(response);
        }
    }
}
