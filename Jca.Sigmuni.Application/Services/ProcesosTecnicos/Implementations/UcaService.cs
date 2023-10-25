using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ucas;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class UcaService : IUcaService
    {

        private readonly IMapper _mapper;
        private readonly IUcaRepository _ucaRepository;

        public UcaService(IMapper mapper, IUcaRepository ucaRepository)
        {
            _mapper = mapper;
            _ucaRepository = ucaRepository;
        }
        public async Task<IList<UcaDto>> FindAll()
        {
            var response = await _ucaRepository.FindAll();

            return _mapper.Map<IList<UcaDto>>(response);
        }



    }
}
