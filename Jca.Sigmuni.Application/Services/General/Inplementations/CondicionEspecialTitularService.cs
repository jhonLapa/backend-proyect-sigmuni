using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.CondicionEspecialTitulares;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class CondicionEspecialTitularService : ICondicionEspecialTitularService
    {
        private readonly IMapper _mapper;
        private readonly ICondicionEspecialTitularRepository _condicionEspecialTitularRepository;

        public CondicionEspecialTitularService(IMapper mapper, ICondicionEspecialTitularRepository condicionEspecialTitularRepository)
        {
            _mapper = mapper;
            _condicionEspecialTitularRepository = condicionEspecialTitularRepository;
        }
        public async Task<IList<CondicionEspecialTitularDto>> FindAll()
        {
            var response = await _condicionEspecialTitularRepository.FindAll();

            return _mapper.Map<IList<CondicionEspecialTitularDto>>(response);
        }
    }
}
