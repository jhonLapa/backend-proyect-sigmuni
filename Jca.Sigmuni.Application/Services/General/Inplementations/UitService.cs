using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.Uits;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    internal class UitService : IUitService
    {
        private readonly IMapper _mapper;
        private readonly IUitRepository _uitRepository;

        public UitService(IMapper mapper, IUitRepository uitRepository)
        {
            _mapper = mapper;
            _uitRepository = uitRepository;
        }

        public async Task<UitDto> ObtenerMontoUitxAnio(int anio)
        {

            var entidad = await _uitRepository.BuscarPorAnioTupaAsunc(anio);
            if (entidad == null)
            {

                throw new Exception("No existe un % de Uit para el Año: " + anio);
                return _mapper.Map<UitDto>(entidad);

            }

            return  _mapper.Map<UitDto>(entidad);

        }

    }
}
