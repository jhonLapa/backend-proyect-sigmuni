using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Depreciaciones;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class DepreciacionService : IDepreciacionService
    {
        private readonly IMapper _mapper;
        
        private readonly IDepreciacionRepository _depreciacionRepository;

        public DepreciacionService(
            IMapper mapper,
            IDepreciacionRepository depreciacionRepository
            
        )

        {
            _mapper = mapper;
            _depreciacionRepository = depreciacionRepository;
            
        }
        public async Task<DepreciacionDto> ObtenerAsync(int id)
        {
            
            var entidad = await _depreciacionRepository.Find(id);

            var dto = _mapper.Map<DepreciacionDto>(entidad);
            return  dto;
        }

        public async Task<List<DepreciacionDto>> ListarGlobalAsync()
        {
            var entidad = await _depreciacionRepository.FindAll();

            var dto = _mapper.Map<List<DepreciacionDto>>(entidad);
            return dto;
        }

        public async Task<List<DepreciacionDto>> ListarFiltroAsync(DepreciacionDto peticion)
        {
           
           // var porcentaje = !string.IsNullOrWhiteSpace(peticion.Filtro.Porcentaje) ? Convert.ToDecimal(peticion.Filtro.Porcentaje) : new decimal?();

            var entidad = await _depreciacionRepository.ListarPorFiltro(peticion.Estado, peticion.IdClasificacionPredio, peticion.IdAntiguedad, peticion.IdMep, peticion.IdEcs, peticion.Porcentaje);

            var dto = _mapper.Map<List<DepreciacionDto>>(entidad);
            return dto;
        }

        public async Task<bool> CrearOActualizarAsync(DepreciacionDto peticion)
        {
           

           
            var entidad = await _depreciacionRepository.Find(peticion.IdDepreciacion);

            if (entidad == null)
            {
                entidad = new Depreciacion();
            }

            

            entidad.Porcentaje = peticion.Porcentaje;
            entidad.IdClasificacionPredio = peticion.IdClasificacionPredio;
            entidad.IdAntiguedad = peticion.IdAntiguedad;
            entidad.IdMep = peticion.IdMep;
            entidad.IdEcs = peticion.IdEcs;

            if (entidad.IdDepreciacion == 0)
            {
                var validarDepreciacion = await _depreciacionRepository.BuscarPorClasificacionEstadoAntiguedad(peticion.IdClasificacionPredio ?? 0, peticion.IdAntiguedad ?? 0, peticion.IdMep ?? 0, peticion.IdEcs ?? 0);

                if (validarDepreciacion != null)
                {
                    if (validarDepreciacion.Estado == false)
                    {
                        validarDepreciacion.Estado = true;
                        await _depreciacionRepository.Edit(validarDepreciacion.IdDepreciacion , validarDepreciacion);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    await _depreciacionRepository.Create(entidad);
                }
            }
            else
            {
                await _depreciacionRepository.Edit(entidad.IdDepreciacion,entidad);
            }

           

            return true;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            

            var entidad = await _depreciacionRepository.Find(id);
            if (entidad == null)
            {
                return false;
            }
            entidad.Estado = false;
            await _depreciacionRepository.Edit(entidad.IdDepreciacion ,entidad);

            

            return true;
        }

        public async Task<ResponsePagination<DepreciacionDto>> PaginatedSearch(RequestPagination<DepreciacionDto> dto)
        {
            var lfdto = new RequestPagination<DepreciacionDto>()
            {
                Page = dto.Page,
                PerPage = dto.PerPage,
                Filter = dto.Filter,
            };

            var entity = _mapper.Map<RequestPagination<Depreciacion>>(lfdto);
            var response = await _depreciacionRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<DepreciacionDto>>(response);
        }
    }
}
