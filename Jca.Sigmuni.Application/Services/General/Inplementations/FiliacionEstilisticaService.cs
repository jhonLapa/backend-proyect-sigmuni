using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.FiliacionesEstilisticas;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class FiliacionEstilisticaService : IFiliacionEstilisticaService
    {
        private readonly IMapper _mapper;
        private readonly IFiliacionEstilisticaRepository _filiacionEstilisticaRepository;

        public FiliacionEstilisticaService(IMapper mapper, IFiliacionEstilisticaRepository filiacionEstilisticaRepository)
        {
            _mapper = mapper;
            _filiacionEstilisticaRepository = filiacionEstilisticaRepository;
        }
        public async Task<IList<FiliacionEstilisticaDto>> FindAll()
        {
            var response = await _filiacionEstilisticaRepository.FindAll();

            return _mapper.Map<IList<FiliacionEstilisticaDto>>(response);
        }
    }
}
