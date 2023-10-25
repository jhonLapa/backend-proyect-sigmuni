using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Autoridades;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Naturalezas;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations
{
    public class NaturalezaService : INaturalezaService
    {
        private readonly IMapper _mapper;
        private readonly INaturalezaRepository _naturalezaRepository;

        public NaturalezaService(IMapper mapper, INaturalezaRepository naturalezaRepository)
        {
            _mapper = mapper;
            _naturalezaRepository = naturalezaRepository;
        }

        public async Task<IList<NaturalezaDto>> findAll()
        {
            var response = await _naturalezaRepository.FindAll();

            return _mapper.Map<IList<NaturalezaDto>>(response);
        }
    }
}
