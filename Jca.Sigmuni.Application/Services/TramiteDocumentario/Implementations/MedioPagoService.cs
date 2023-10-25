using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.MedioPagos;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations
{
    public class MedioPagoService : IMedioPagoService
    {

        private readonly IMapper _mapper;
        private readonly IMedioPagoRepository _MedioPagoRepository;

        public MedioPagoService(IMapper mapper, IMedioPagoRepository MedioPagoRepository)
        {
            _mapper = mapper;
            _MedioPagoRepository = MedioPagoRepository;
        }
        public async Task<IList<MedioPagoDto>> FindAll()
        {
            var response = await _MedioPagoRepository.FindAll();

            return _mapper.Map<IList<MedioPagoDto>>(response);
        }



    }
}
