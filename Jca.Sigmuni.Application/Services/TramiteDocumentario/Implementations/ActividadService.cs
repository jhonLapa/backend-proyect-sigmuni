using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Actividades;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations
{
    public class ActividadService : IActividadService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IActividadRepository _actividadRepository;

        public ActividadService(IMapper mapper,IActividadRepository actividadRepository,ApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
            _actividadRepository = actividadRepository;
        }

        public Task<ActividadDto> Create(ActividadFormDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ActividadDto>> Createmultiple(List<ActividadDto> actividades ,int idProcedimiento)
        {
            foreach (var actividad in actividades)
            {
                var entidadActividadProcedimiento = await _actividadRepository.BuscarActividadPorIdProcedimientoAsync(idProcedimiento, actividad.Id);
                if (entidadActividadProcedimiento == null)
                {
                    int? idTipoActividad = default(int?);
                    if (actividad.TipoActividad != null)
                    { idTipoActividad = actividad.TipoActividad.IdTipoActividad; }
                    else { idTipoActividad = null; }

                    int? idArea = default(int?);
                    if (actividad.Area!= null)
                    { idArea = actividad.Area.Id; }
                    else { idArea = null; }

                    int? idAccionGenerar = default(int?);
                    if (actividad.AccionGenerar != null)
                    { idAccionGenerar = actividad.AccionGenerar.IdAccionGenerar; }
                    else { idAccionGenerar = null; }

                    int? idResultado = default(int?);
                    if (actividad.Resultado != null)
                    { idResultado = actividad.Resultado.Id; }
                    else { idResultado = null; }

                    int? idResultado2 = default(int?);
                    if (actividad.Resultado2 != null)
                    { idResultado2 = actividad.Resultado2.Id; }
                    else { idResultado2 = null; }

                    var entidadActividad = new Actividad()
                    {
                        NumeroActividad = actividad.NumeroActividad,
                        NumeroActividadAnterior = actividad.NumeroActividadAnterior,
                        NumeroActividadSiguiente = actividad.NumeroActividadSiguiente,
                        Descripcion = actividad.Descripcion,
                        PlazoAtencion = actividad.PlazoAtencion,
                        NotificacionCorreo = actividad.NotificacionCorreo,
                        Flag = actividad.Flag,
                        IdTipoActividad = idTipoActividad,
                        IdProcedimiento = idProcedimiento,
                        IdAccionGenerar = idAccionGenerar,
                        UltimoPaso = actividad.UltimoPaso,
                        Observacion = actividad.Observacion,
                        IdResultado = idResultado != 0 ? idResultado : new int?(),
                        IdResultadoII = idResultado2 != 0 ? idResultado2 : new int?(),
                        IdArea = idArea
                    };
                    if (entidadActividad.Id == 0)
                    {
                        _context.Actividades.Add(entidadActividad);
                    }
                    else { _context.Actividades.Update(entidadActividad); }
                    
                }
            }

            await _context.SaveChangesAsync();
            return actividades;
        }

        public Task<ActividadDto?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActividadDto?> Edit(int id, ActividadFormDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ActividadDto?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ActividadDto>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponsePagination<ActividadDto>> PaginatedSearch(RequestPagination<ActividadDto> dto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> VerificarSiRequiereInspeccionSolicitudAsync(int IdProcedimiento)
        {
            var verifica = false;
            var entidad = await _actividadRepository.ListarPorIdYCodigoTipoActividadAsync(IdProcedimiento, Jca.Sigmuni.Domain.TramiteDocumentario.Enums.TipoActividad.AsignarInspeccion);
            if (entidad.Count>0) 
            {
                return verifica = true;
            }
            return verifica;
        }
    }
}
