using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ClasificacionValorUnitarios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ecss;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class ClasificacionValorUnitarioService : IClasificacionValorUnitarioService
    {
        private readonly IMapper _mapper;
        private readonly IClasificacionValorUnitarioRepository _clasificacionValorUnitarioRepository;

        public ClasificacionValorUnitarioService(IMapper mapper, IClasificacionValorUnitarioRepository clasificacionValorUnitarioRepository)
        {
            _mapper = mapper;
            _clasificacionValorUnitarioRepository = clasificacionValorUnitarioRepository;
        }

        public async Task<IList<ClasificacionValorUnitarioDto>> FindAll()
        {
            var response = await _clasificacionValorUnitarioRepository.FindAll();

            return _mapper.Map<IList<ClasificacionValorUnitarioDto>>(response);
        }
    }
}
