using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.ProcedimientoRequisitos;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations
{
    public class ProcedimientoRequisitoService : IProcedimientoRequisitoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IProcedimientoRequisitoRepository _procedimientoRequisitoRepository;

        public ProcedimientoRequisitoService(ApplicationDbContext context, IMapper mapper, IProcedimientoRequisitoRepository procedimientoRequisitoRepository)
        {
            _context = context;
            _mapper = mapper;
            _procedimientoRequisitoRepository= procedimientoRequisitoRepository;
        }

        async Task<IList<ProcedimientoRequisitoDto>> IProcedimientoRequisitoService.ListarPorProcedimiento(int idProcedimiento)
        {
            var response = await _procedimientoRequisitoRepository.ListarxProcedimientoAsync(idProcedimiento);
            return _mapper.Map<IList<ProcedimientoRequisitoDto>>(response);
        }

        public async Task<ProcedimientoRequisitoDto?> Disable(int id)
        {
            var response = await _procedimientoRequisitoRepository.Disable(id);

            return _mapper.Map<ProcedimientoRequisitoDto>(response);
        }

    }
}
