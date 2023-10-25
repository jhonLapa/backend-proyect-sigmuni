using AutoMapper;
using Jca.Sigmuni.Application.Dtos.CompendioNormas.NormasInteres;
using Jca.Sigmuni.Application.Dtos.General.TipoPersonas;
using Jca.Sigmuni.Application.Services.CompendioNormas.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.CompendioNormas;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.CompendioNormas.Abastractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.CompendioNormas.Inplementations
{
    public class NormaInteresService : INormaInteresService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly INormaInteresRepository _normaInteresRepository;
        private readonly INormaDiaDetalleRepository _normaDiaDetalleRepository;

        public NormaInteresService(IMapper mapper, INormaInteresRepository normaInteresRepository, INormaDiaDetalleRepository normaDiaDetalleRepository,ApplicationDbContext context)
        {
            _mapper = mapper;
            _normaInteresRepository = normaInteresRepository;
            _normaDiaDetalleRepository = normaDiaDetalleRepository;
            _context = context;
        }
        public async Task<NormaInteresDto> Create(NormaInteresFormDto dto)
        {

            var normaDiaDetalle = new NormaDiaDetalle();
            var idNormaDiaDetalle = 0;
            normaDiaDetalle.Nombre = dto.NormaDiaDetalle.Nombre;
            normaDiaDetalle.Sumilla = dto.NormaDiaDetalle.Sumilla;
            normaDiaDetalle.Enlace = dto.NormaDiaDetalle.Enlace;
            var entityDetalle = _mapper.Map<NormaDiaDetalle>(normaDiaDetalle);
            var responseDetalle = await _normaDiaDetalleRepository.Create(entityDetalle);


            if(responseDetalle != null)
            {
                idNormaDiaDetalle = responseDetalle.IdNormaDiaDetalle;
            }

            var normaInteres = new NormaInteres();

            normaInteres.PaginasInteres = dto.PaginasInteres;
            normaInteres.observacion = dto.Observacion;
            normaInteres.ArticuloNormaDerogado = dto.ArticuloNormaDerogado;
            normaInteres.ObservacionNormaDerogado = dto.ObservacionNormaDerogado;
            normaInteres.IdNormaDiaDetalle = idNormaDiaDetalle;
            normaInteres.IdDocumento = dto.IdDocumento;
            normaInteres.IdUsuario = dto.IdUsuario;
            normaInteres.IdDocumento = dto.IdDocumento;
            normaInteres.IdTipoNorma = dto.IdTipoNorma;
            normaInteres.IdNaturaleza = dto.IdNaturaleza;
            normaInteres.IdAutoridad = dto.IdAutoridad;
            normaInteres.IdEstadoNorma = dto.IdEstadoNorma;
            normaInteres.Nombre = dto.Nombre;
            normaInteres.Sumilla = dto.Sumilla;
            normaInteres.IdTipoNorma = dto.IdTipoNorma;
            normaInteres.FechaRegistro = dto.FechaRegistro;

            var entity = _mapper.Map<NormaInteres>(normaInteres);
            var response = await _normaInteresRepository.Create(entity);

            if(dto.NormaDerogada!=null)
            {
                foreach(var item in dto.NormaDerogada)
                {
                    var normaDerogada = new NormaDerogada();
                    normaDerogada.IdNormaInteres = response.IdNormaInteres;
                    normaDerogada.ArticuloModificado = item.ArticuloModificado;
                    normaDerogada.NotaObservacion= item.NotaObservacion;
                    if (item.NormaInteresDerogada != null)
                    {
                        normaDerogada.IdNormaInteresDerogada = item.NormaInteresDerogada.IdNormaInteres;
                    }
                    normaDerogada.IdEstadoNorma=item.IdEstadoNorma;

                    _context.NormaDerogada.Add(normaDerogada);
                    await _context.SaveChangesAsync();  
                }
            }


            return _mapper.Map<NormaInteresDto>(response);

        }
        public async Task<NormaInteresDto?> Disable(int id)
        {
            var response = await _normaInteresRepository.Disable(id);

            return _mapper.Map<NormaInteresDto>(response);
        }
        public async Task<NormaInteresDto?> Edit(int id, NormaInteresFormDto dto)
        {
            var finNormaInteres = await _normaInteresRepository.Find(id);
            var idDetalle = 0;
            if (finNormaInteres != null)
            {
                idDetalle = finNormaInteres.IdNormaDiaDetalle;
            }

            var normaDiaDetalle = new NormaDiaDetalle();

            if(dto.NormaDiaDetalle != null)
            {
                normaDiaDetalle.Nombre = dto.NormaDiaDetalle.Nombre;
                normaDiaDetalle.Sumilla = dto.NormaDiaDetalle.Sumilla;
                normaDiaDetalle.Enlace = dto.NormaDiaDetalle.Enlace;
                normaDiaDetalle.IdAutoridad = dto.NormaDiaDetalle.IdAutoridad;
                var entityDetalle = _mapper.Map<NormaDiaDetalle>(normaDiaDetalle);
                await _normaDiaDetalleRepository.Edit(idDetalle, entityDetalle);
            }
            
            
            var normaInteres = new NormaInteres();

            normaInteres.PaginasInteres = dto.PaginasInteres;
            normaInteres.observacion = dto.Observacion;
            normaInteres.ArticuloNormaDerogado = dto.ArticuloNormaDerogado;
            normaInteres.ObservacionNormaDerogado = dto.ObservacionNormaDerogado;
            normaInteres.IdNormaDiaDetalle = idDetalle;
            normaInteres.IdUsuario = dto.IdUsuario;
            normaInteres.IdDocumento = dto.IdDocumento;
            normaInteres.IdTipoNorma = dto.IdTipoNorma;
            normaInteres.IdNaturaleza = dto.IdNaturaleza;
            normaInteres.IdAutoridad = dto.IdAutoridad;
            normaInteres.IdEstadoNorma = dto.IdEstadoNorma;
            normaInteres.Nombre = dto.Nombre;
            normaInteres.Sumilla = dto.Sumilla;
            normaInteres.IdTipoNorma = dto.IdTipoNorma;
            normaInteres.FechaRegistro = dto.FechaRegistro;

            var entity = _mapper.Map<NormaInteres>(normaInteres);
            var response = await _normaInteresRepository.Edit(id, entity);
            if (dto.NormaDerogada != null)
            {
                foreach (var item in dto.NormaDerogada)
                {
                    var normaDerogada = await _context.NormaDerogada.FindAsync(item.IdNormaDerogada);
                    if(normaDerogada == null)
                    {
                        normaDerogada = new NormaDerogada();
                    }
                    
                    normaDerogada.IdNormaInteres = item.IdNormaInteres;
                    normaDerogada.ArticuloModificado = item.ArticuloModificado;
                    normaDerogada.NotaObservacion = item.NotaObservacion;
                    
                    if(item.NormaInteresDerogada != null)
                    {
                        normaDerogada.IdNormaInteresDerogada = item.NormaInteresDerogada.IdNormaInteres;
                    }
                    
                    normaDerogada.IdEstadoNorma = item.IdEstadoNorma;
                    if (item.IdNormaDerogada == 0)
                    {
                        _context.NormaDerogada.Add(normaDerogada);
                    }
                    else
                    {
                        _context.NormaDerogada.Update(normaDerogada);
                    }
                    
                    await _context.SaveChangesAsync();
                }
            }

            return _mapper.Map<NormaInteresDto>(response);
        }
        public async Task<NormaInteresDto?> Find(int id)
        {
            var response = await _normaInteresRepository.Find(id);

            var mapeo = _mapper.Map<NormaInteresDto>(response);
            return mapeo;
        }

        public async Task<NormaDiaDetalleDto> FindNormaDetalleAsync(int id)
        {
            var response = await _normaDiaDetalleRepository.Find(id);
            

            var mapeo = _mapper.Map<NormaDiaDetalleDto>(response);
            return mapeo;
        }
        public async Task<IList<NormaInteresDto>> FindAll()
        {
            var response = await _normaInteresRepository.FindAll();
            var temporal = 0;

            return _mapper.Map<IList<NormaInteresDto>>(response);
        }
        public async Task<ResponsePagination<NormaInteresDto>> PaginatedSearch(RequestPagination<NormaInteresDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<NormaInteres>>(dto);
            var response = await _normaInteresRepository.PaginatedSearchFiltros(entity,dto.Filter.FechaRegistroDesde,dto.Filter.FechaRegistroHasta);

            return _mapper.Map<ResponsePagination<NormaInteresDto>>(response);
        }
    }
}
