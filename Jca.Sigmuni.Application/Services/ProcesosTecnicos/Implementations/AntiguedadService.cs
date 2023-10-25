using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Antiguedades;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CategoriaConstrucciones;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class AntiguedadService : IAntiguedadService
    {
        private readonly IMapper _mapper;
        private readonly IAntiguedadRepository _AntiguedadRepository;

        public AntiguedadService(IMapper mapper, IAntiguedadRepository AntiguedadRepository)
        {
            _mapper = mapper;
            _AntiguedadRepository = AntiguedadRepository;
        }
        public async Task<IList<AntiguedadDto>> FindAll()
        {
            var response = await _AntiguedadRepository.FindAll();

            return _mapper.Map<IList<AntiguedadDto>>(response);
        }
    }
}
