using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.PredioCatastralesAn;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class PredioCatastralAnService : IPredioCatastralAnService
    {

        private readonly IMapper _mapper;
        private readonly IPredioCatastralAnRepository _predioCatastralAnRepository;

        public PredioCatastralAnService(IMapper mapper, IPredioCatastralAnRepository predioCatastralAnRepository)
        {
            _mapper = mapper;
            _predioCatastralAnRepository = predioCatastralAnRepository;
        }
        public async Task<IList<PredioCatastralAnDto>> FindAll()
        {
            var response = await _predioCatastralAnRepository.FindAll();

            return _mapper.Map<IList<PredioCatastralAnDto>>(response);
        }



    }
}
