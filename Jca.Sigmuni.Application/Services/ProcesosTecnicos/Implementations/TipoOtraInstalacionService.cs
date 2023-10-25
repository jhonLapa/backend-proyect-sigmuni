using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoInteriores;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoOtrasInstalaciones;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class TipoOtraInstalacionService : ITipoOtraInstalacionService
    {
        private readonly IMapper _mapper;
        private readonly ITipoOtraInstalacionRepository _tipoOtraInstalacionRepository;
        public TipoOtraInstalacionService(IMapper mapper, ITipoOtraInstalacionRepository tipoOtraInstalacionRepository)
        {
            _mapper = mapper;
            _tipoOtraInstalacionRepository = tipoOtraInstalacionRepository;
        }

        public async Task<IList<TipoOtraInstalacionDto>> FindAll()
        {
            var response = await _tipoOtraInstalacionRepository.FindAll();

            return _mapper.Map<IList<TipoOtraInstalacionDto>>(response);
        }
    }
}
