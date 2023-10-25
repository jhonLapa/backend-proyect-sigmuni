using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.AfectacionesAntropicas;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class AfectacionAntropicaService : IAfectacionAntropicaService
    {
        private readonly IMapper _mapper;
        private readonly IAfectacionAntropicaRepository _afectacionAntropicaRepository;

        public AfectacionAntropicaService(IMapper mapper, IAfectacionAntropicaRepository afectacionAntropicaRepository)
        {
            _mapper = mapper;
            _afectacionAntropicaRepository = afectacionAntropicaRepository;
        }
        public async Task<IList<AfectacionAntropicaDto>> FindAll()
        {
            var response = await _afectacionAntropicaRepository.FindAll();

            return _mapper.Map<IList<AfectacionAntropicaDto>>(response);
        }
    }
}
