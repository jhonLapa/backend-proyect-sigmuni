using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.GirosAutorizados;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class GiroAutorizadoService : IGiroAutorizadoService
    {
       
            private readonly IMapper _mapper;
        private readonly IGiroAutorizadoRepository _giroAutorizadoRepository;

            public GiroAutorizadoService(IMapper mapper, IGiroAutorizadoRepository giroAutorizadoRepository)
            {
                _mapper = mapper;
                _giroAutorizadoRepository = giroAutorizadoRepository;
            }
        public async Task<IList<GiroAutorizadoDto>> FindAll()
        {
            var response = await _giroAutorizadoRepository.FindAll();

            return _mapper.Map<IList<GiroAutorizadoDto>>(response);
        }



    }
}
