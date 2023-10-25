using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.ProcedimientoNormaIntereses;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations
{
    public class ProcedimientoNormaInteresService : IProcedimientoNormaInteresService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IProcedimientoNormaInteresRepository _procedimientoNormaInteresRepository;

        public ProcedimientoNormaInteresService(ApplicationDbContext context, IMapper mapper, IProcedimientoNormaInteresRepository procedimientoNormaInteresRepository)
        {
            _context = context;
            _mapper = mapper;
            _procedimientoNormaInteresRepository = procedimientoNormaInteresRepository;
        }

        public async Task<List<ProcedimientoNormaInteresDto>> CreateMultipleNormaInteres(List<ProcedimientoNormaInteresDto> normasIntereses, int idProcedimiento)
        {
            var idnormaInteres = 0;
            foreach (var normaInteres in normasIntereses)
            {
                idnormaInteres = normaInteres.IdNormaInteres ?? 0;
                if (idnormaInteres != 0)
                {
                    var entidadProcedimientoNorma = await _procedimientoNormaInteresRepository.BuscarProcedimientoNormaInterePorIdAsync(idProcedimiento, idnormaInteres);
                    if (entidadProcedimientoNorma == null)
                    {
                        var procNormaInteres = new ProcedimientoNormaInteres()
                        {
                            IdNormaInteres = idnormaInteres,
                            IdProcedimiento = idProcedimiento,
                            Estado = normaInteres.Estado
                        };
                        _context.ProcedimientoNormaIntereses.Add(procNormaInteres);

                    }
                    else
                    {
                        entidadProcedimientoNorma.IdNormaInteres+= idnormaInteres;
                        entidadProcedimientoNorma.IdProcedimiento+= idProcedimiento;
                        entidadProcedimientoNorma.Estado=normaInteres.Estado;
                        _context.ProcedimientoNormaIntereses.Update(entidadProcedimientoNorma);
                    }
                }
            }
            await _context.SaveChangesAsync();
            return normasIntereses;
        }
    }
}
