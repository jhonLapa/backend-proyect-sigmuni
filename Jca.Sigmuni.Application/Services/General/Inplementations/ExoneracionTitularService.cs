using AutoMapper;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jca.Sigmuni.Application.Dtos.General.ExoneracionTitulares;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class ExoneracionTitularService : IExoneracionTitularService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ExoneracionTitularService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ExoneracionTitularDto> CrearExoneracion(ExoneracionTitularDto entity, int idPersona)
        {
            var entidad = await _context.ExoneracionTitulares.FindAsync(entity.IdExoneracionTitular);
            if (entidad == null)
            {
                entidad = new ExoneracionTitular();
            }

            entidad.NumeroResolucion= entity.NumeroResolucion;
            entidad.NumeroBoletaPension= entity.NumeroBoletaPension;
            entidad.FechaInicio= entity.FechaInicio;
            entidad.FechaVencimiento= entity.FechaVencimiento;
            if(entity.TipoExoneracion!=null)
            {
                entidad.IdTipoExoneracion = entity.TipoExoneracion.IdTipoExoneracion;
            }
            if(entity.CondicionEspecialTitular!=null)
            {
                entidad.IdCondicionEspecialTitular = entity.CondicionEspecialTitular.IdCondicionEspecialTitular;
            }
            entidad.IdPersona = idPersona;
           
            if(entity.IdExoneracionTitular == 0) 
            {
                _context.ExoneracionTitulares.Add(entidad);
            }
            else { _context.ExoneracionTitulares.Update(entidad); }
            await _context.SaveChangesAsync();
            var response = _mapper.Map<ExoneracionTitular>(entidad);
            return _mapper.Map<ExoneracionTitularDto>(response);   
        }
    }
}
