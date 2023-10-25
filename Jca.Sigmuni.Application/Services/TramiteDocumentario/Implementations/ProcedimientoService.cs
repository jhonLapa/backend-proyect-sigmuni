using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.CategoriaRangos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Procedimientos;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations
{
    public class ProcedimientoService : IProcedimientoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IProcedimientoRepository _procedimientoRepository;

        public ProcedimientoService(IMapper mapper, IProcedimientoRepository procedimientoRepository,ApplicationDbContext context)
        {
            _context= context;  
            _mapper = mapper;
            _procedimientoRepository = procedimientoRepository;
        }

        public async Task<ProcedimientoDto> Create(ProcedimientoFormDto dto)
        {
            var entity=_mapper.Map<Procedimiento>(dto);
            var response =await _procedimientoRepository.Create(entity);
            return _mapper.Map<ProcedimientoDto>(response);
        }

        public async Task<ProcedimientoDto?> Disable(int id)
        {
            var response =await _procedimientoRepository.Disable(id);
            return _mapper.Map<ProcedimientoDto>(response);
        }

        public Task<ProcedimientoDto?> Edit(int id, ProcedimientoFormDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<ProcedimientoDto?> Find(int id)
        {
            var response = await _procedimientoRepository.Find(id);
            return _mapper.Map<ProcedimientoDto>(response);
        }

        public async Task<IList<ProcedimientoDto>> FindTramite(int idTipoTramite)
        {
            var response = await _procedimientoRepository.FindTramite(idTipoTramite);
            return _mapper.Map<IList<ProcedimientoDto>>(response);
        }

        public async Task<IList<ProcedimientoDto>> FindAll()
        {
            var response = await _procedimientoRepository.FindAll();
            return _mapper.Map<IList<ProcedimientoDto>>(response);
        }

        public async Task<ResponsePagination<ProcedimientoDto>> PaginatedSearch(RequestPagination<ProcedimientoDto> dto)
        {
            var entity =_mapper.Map<RequestPagination<Procedimiento>>(dto);
            var response =await _procedimientoRepository.PaginatedSearchFiltros(entity,dto.Filter.FechaRegistroDesde, dto.Filter.FechaRegistroHasta);
            return _mapper.Map<ResponsePagination<ProcedimientoDto>>(response);
        }

        public async Task<ProcedimientoDto> CreateProcedimiento(ProcedimientoDto entity)
        {
            var entidad = await _context.Procedimientos.FindAsync(entity.Id);
            if (entidad == null)
            {
                entidad = new Procedimiento();
            }
            entidad.AsuntoTramite = entity.AsuntoTramite;
            entidad.Descripcion = entity.Descripcion;
            entidad.IdUsuario = entity.IdUsuario;
            entidad.IdTipoTramite = entity.TipoTramite.IdTipoTramite;
            entidad.Normativa = entity.Normativa;
            entidad.Codigo = entity.Codigo;
            entidad.EsParaVirtual= entity.EsParaVirtual;

            if (entity.Id == 0)
            {
                entidad.RequiereCuc = 0;
                _context.Procedimientos.Add(entidad);
            }
            else
            {
                _context.Procedimientos.Update(entidad);
            }

            await _context.SaveChangesAsync();
            var response = _mapper.Map<Procedimiento>(entidad);
            return _mapper.Map<ProcedimientoDto>(response);
        }

        public async Task<ProcedimientoDto> ObtenerUltimoSolicitud()
        {
            var response=await _procedimientoRepository.ObtenerUltimoProcedimiento();
            return _mapper.Map<ProcedimientoDto>(response);
        }

    }
}

