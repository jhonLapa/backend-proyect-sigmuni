using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.FiliacionesCronologicas;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class FiliacionCronologicaService : IFiliacionCronologicaService
    {
        private readonly IMapper _mapper;
        private readonly IFiliacionCronologicaRepository _filiacionCronologicaRepository;

        public FiliacionCronologicaService(IMapper mapper, IFiliacionCronologicaRepository filiacionCronologicaRepository)
        {
            _mapper = mapper;
            _filiacionCronologicaRepository = filiacionCronologicaRepository;
        }
        public async Task<IList<FiliacionCronologicaDto>> FindAll()
        {
            var response = await _filiacionCronologicaRepository.FindAll();

            return _mapper.Map<IList<FiliacionCronologicaDto>>(response);
        }
    }
}
