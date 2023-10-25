using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.PrediosCatastralesEn;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class PredioCatastralEnService : IPredioCatastralEnService
    {

        private readonly IMapper _mapper;
        private readonly IPredioCatastralEnRepository _predioCatastralEnRepository;

        public PredioCatastralEnService(IMapper mapper, IPredioCatastralEnRepository predioCatastralEnRepository)
        {
            _mapper = mapper;
            _predioCatastralEnRepository = predioCatastralEnRepository;
        }
        public async Task<IList<PredioCatastralEnDto>> FindAll()
        {
            var response = await _predioCatastralEnRepository.FindAll();

            return _mapper.Map<IList<PredioCatastralEnDto>>(response);
        }



    }
}
