using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.AreaTerrenoInvalids;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class AreaTerrenoInvalidService : IAreaTerrenoInvalidService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AreaTerrenoInvalidService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AreaTerrenoInvalid> CreateAreaTerreno(AreaTerrenoInvalidDto entity)
        {
            var entidad = await _context.AreaTerrenoInvalids.FindAsync(entity.IdEvaluacion);

            if (entidad == null)
            {
                entidad=new AreaTerrenoInvalid();
            }
            entidad.LoteColindante=entity.LoteColindante;
            entidad.JardinAislamiento=entity.JardinAislamiento;
            entidad.AreaPublica=entity.AreaPublica;
            entidad.AreaIntangible=entity.AreaIntangible;
            entidad.IdFicha=entity.IdFicha;

            if(entity.IdEvaluacion==0)
            {
                _context.AreaTerrenoInvalids.Add(entidad);
            }
            else
            {
                entidad.IdEvaluacion=entity.IdEvaluacion;
                _context.AreaTerrenoInvalids.Update(entidad);
            }

            await _context.SaveChangesAsync();

            return entidad;

        }
    }
}
