using AutoMapper;
using Jca.Sigmuni.Application.Dtos.Admins.Area;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaBusquedas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ValorObraComplementarias;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ValorUnitarios;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class ValorUnitarioService : IValorUnitarioService
    {
        private readonly IMapper _mapper;
        private readonly IValorUnitarioRepository _valorUnitarioRepository;

        public ValorUnitarioService(IMapper mapper, IValorUnitarioRepository valorUnitarioRepository)
        {
            _mapper = mapper;
            _valorUnitarioRepository = valorUnitarioRepository;
        }

        public async Task<ValorUnitarioDto> CrearOActualizarAsync(ValorUnitarioDto peticion)
        {
            var id = peticion.IdValorUnitario;
            var entidad = await _valorUnitarioRepository.Find(id);

            if (entidad == null)
            {
                entidad = new ValorUnitario();
            }

            var idClasificacionValUnitario = new int?();
            var idCategoriaValUnitario = new int?();

            if (peticion.ClasificacionValorUnitario != null)
            {
                idClasificacionValUnitario = peticion.ClasificacionValorUnitario.Id != 0 && peticion.ClasificacionValorUnitario.Id != null ? peticion.ClasificacionValorUnitario.Id : new int?();
            }

            if (peticion.CategoriaValorUnitario != null)
            {
                idCategoriaValUnitario = peticion.CategoriaValorUnitario.IdCategoriaConstruccion != 0 && peticion.CategoriaValorUnitario.IdCategoriaConstruccion != null ? peticion.CategoriaValorUnitario.IdCategoriaConstruccion : new int?();
            }

            entidad.Anio = peticion.Anio;
            entidad.Descripcion = peticion.Descripcion;
            entidad.Valor = peticion.Valor;
            entidad.IdClasificacionValUnitario = idClasificacionValUnitario;
            entidad.IdCategoriaValUnitario = idCategoriaValUnitario;
            entidad.Estado = peticion.Estado;

            if (entidad.IdValorUnitario == 0)
            {
                var response = await _valorUnitarioRepository.Create(entidad);
                return _mapper.Map<ValorUnitarioDto>(response);
            }
            else
            {
                var response = await _valorUnitarioRepository.Edit(entidad.IdValorUnitario, entidad);
                return _mapper.Map<ValorUnitarioDto>(response);
            }
        }

        public async Task<ValorUnitarioDto?> Disable(int id)
        {
            var response = await _valorUnitarioRepository.Disable(id);

            return _mapper.Map<ValorUnitarioDto>(response);
        }

        public async Task<ValorUnitarioDto> ObtenerAsync(int idValUnitario)
        {
            var entidad = await _valorUnitarioRepository.Find(idValUnitario);

            return _mapper.Map<ValorUnitarioDto>(entidad);
        }

        public async Task<ResponsePagination<ValorUnitarioDto>> SelectPaginatedSearch(RequestPagination<ValorUnitarioDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<ValorUnitario>>(dto);
            var response = await _valorUnitarioRepository.PaginatedSearch(entity);
            return _mapper.Map<ResponsePagination<ValorUnitarioDto>>(response);
        }
    }
}
