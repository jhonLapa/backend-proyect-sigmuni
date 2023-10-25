using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.Motivos;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class MotivoService : IMotivoService
    {

        private readonly IMapper _mapper;
        private readonly IMotivoRepository _MotivoRepository;

        public MotivoService(IMapper mapper, IMotivoRepository MotivoRepository)
        {
            _mapper = mapper;
            _MotivoRepository = MotivoRepository;
        }
        public async Task<IList<MotivoDto>> FindAll()
        {
            var response = await _MotivoRepository.FindAll();

            return _mapper.Map<IList<MotivoDto>>(response);
        }



    }
}
