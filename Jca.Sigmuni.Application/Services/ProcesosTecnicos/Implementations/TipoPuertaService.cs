using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoPuertas;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class TipoPuertaService : ITipoPuertaService
    {

        private readonly IMapper _mapper;
        private readonly ITipoPuertaRepository _tipoPuertaRepository;

        public TipoPuertaService(IMapper mapper, ITipoPuertaRepository tipoPuertaRepository)
        {
            _mapper = mapper;
            _tipoPuertaRepository = tipoPuertaRepository;
        }
        public async Task<IList<TipoPuertaDto>> FindAll()
        {
            var response = await _tipoPuertaRepository.FindAll();

            return _mapper.Map<IList<TipoPuertaDto>>(response);
        }



    }
}
