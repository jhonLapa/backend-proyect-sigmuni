using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.TipoExoneraciones;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class TipoExoneracionService : ITipoExoneracionService
    {
        private readonly IMapper _mapper;
        private readonly ITipoExoneracionRepository _tipoExoneracionRepository;

        public TipoExoneracionService(IMapper mapper, ITipoExoneracionRepository tipoExoneracionRepository)
        {
            _mapper = mapper;
            _tipoExoneracionRepository = tipoExoneracionRepository;
        }   

        public async Task<IList<TipoExoneracionDto>> findAll()
        {
            var response = await _tipoExoneracionRepository.FindAll();
            return _mapper.Map<IList<TipoExoneracionDto>>(response);
        }
    }
}
