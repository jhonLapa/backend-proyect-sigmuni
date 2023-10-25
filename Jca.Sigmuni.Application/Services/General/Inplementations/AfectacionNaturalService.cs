using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.AfectacionesNaturales;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class AfectacionNaturalService : IAfectacionNaturalService
    {
        private readonly IMapper _mapper;
        private readonly IAfectacionNaturalRepository _afectacionNaturalRepository;

        public AfectacionNaturalService(IMapper mapper, IAfectacionNaturalRepository afectacionNaturalRepository)
        {
            _mapper = mapper;
            _afectacionNaturalRepository = afectacionNaturalRepository;
        }
        public async Task<IList<AfectacionNaturalDto>> FindAll()
        {
            var response = await _afectacionNaturalRepository.FindAll();

            return _mapper.Map<IList<AfectacionNaturalDto>>(response);
        }
    }
}
