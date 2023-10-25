using AutoMapper;
using Jca.Sigmuni.Application.Dtos.Admins.AreaCargos;
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
    public class ValorObraComplementariaService : IValorObraComplementariaService
    {
        private readonly IMapper _mapper;
        private readonly IValorObraComplementariaRepository _valorObraComplementariaRepository;
        private readonly ITipoOtraInstalacionRepository _tipoOtraInstalacionRepository;

        public ValorObraComplementariaService(IMapper mapper, IValorObraComplementariaRepository valorObraComplementariaRepository, ITipoOtraInstalacionRepository tipoOtraInstalacionRepository)
        {
            _mapper = mapper;
            _valorObraComplementariaRepository = valorObraComplementariaRepository;
            _tipoOtraInstalacionRepository = tipoOtraInstalacionRepository;
        }

        public async Task<List<ValorObraComplementariaDto>> CrearMasivoAsync(List<ValorObraComplementariaMasivoDto> lista)
        {
            List<ValorObraComplementariaDto> response = new List<ValorObraComplementariaDto>();
            for (int i = 0; i < lista.Count; i++)
            {
                var peticion = lista[i];

                var idValorUnitario = peticion.Id;
                var entidad = await _valorObraComplementariaRepository.Find(idValorUnitario);

                if (entidad == null)
                {
                    entidad = new ValorObraComplementaria();
                }

                var tipoOtraInstalacion = await _tipoOtraInstalacionRepository.BuscarPorCodigoAsync(peticion.Codigo);

                entidad.Anio = peticion.Anio;
                entidad.Descripcion = tipoOtraInstalacion != null ? tipoOtraInstalacion.Descripcion : null;
                entidad.UnidadMedida = tipoOtraInstalacion != null ? tipoOtraInstalacion.UnidadMedida?.Abreviatura : null;
                entidad.Valor = peticion.Valor;
                entidad.Item = tipoOtraInstalacion != null ? Int32.Parse(tipoOtraInstalacion.Codigo) : null;
                entidad.IdTipoOtrasInstalaciones = tipoOtraInstalacion != null ? tipoOtraInstalacion.IdTipoOtraInstalacion : null;

                if (entidad.Id == 0)
                {
                    var validarValObras = await _valorObraComplementariaRepository.BuscarPorTipoOtrasInstalaciones((int)peticion.Anio, tipoOtraInstalacion.Descripcion, tipoOtraInstalacion?.IdTipoOtraInstalacion ?? 0, tipoOtraInstalacion.UnidadMedida?.Abreviatura, (decimal)peticion.Valor, Int32.Parse(tipoOtraInstalacion.Codigo));
                    if (validarValObras != null)
                    {
                        if (validarValObras.Estado == false)
                        {
                            validarValObras.Estado = true;
                            var res = await _valorObraComplementariaRepository.Edit(validarValObras.Id, validarValObras);
                            response.Add(_mapper.Map<ValorObraComplementariaDto>(res));
                        }
                        else
                        {
                            throw new Exception("Valor de Obra Complementaria ya existe");
                        }
                    }
                    else
                    {
                        var res = await _valorObraComplementariaRepository.Create(entidad);
                        response.Add(_mapper.Map<ValorObraComplementariaDto>(res));
                    }
                }
                else
                {
                    var res = await _valorObraComplementariaRepository.Edit(entidad.Id, entidad);
                    response.Add(_mapper.Map<ValorObraComplementariaDto>(res));
                }
            }

            return response;
        }

        public async Task<ValorObraComplementariaDto> CrearOActualizarAsync(ValorObraComplementariaDto peticion)
        {
            var idValorUnitario = peticion.Id;
            var entidad = await _valorObraComplementariaRepository.Find(idValorUnitario);

            if (entidad == null)
            {
                entidad = new ValorObraComplementaria();
            }

            entidad.Anio = peticion.Anio;
            entidad.Descripcion = peticion.Descripcion;
            entidad.UnidadMedida = peticion.UnidadMedida;
            entidad.Valor = peticion.Valor;
            entidad.Item = peticion.Item;
            entidad.IdTipoOtrasInstalaciones = peticion.IdTipoOtrasInstalaciones != null && peticion.IdTipoOtrasInstalaciones != 0 ? peticion.IdTipoOtrasInstalaciones : null;

            if (entidad.Id == 0)
            {
                var validarValObras = await _valorObraComplementariaRepository.BuscarPorTipoOtrasInstalaciones((int)peticion.Anio, peticion.Descripcion, peticion.IdTipoOtrasInstalaciones ?? 0, peticion.UnidadMedida, (decimal)peticion.Valor, (int)peticion.Item);
                if (validarValObras != null)
                {
                    if (validarValObras.Estado == false)
                    {
                        validarValObras.Estado = true;
                        var response = await _valorObraComplementariaRepository.Edit(validarValObras.Id, validarValObras);
                        return _mapper.Map<ValorObraComplementariaDto>(response);
                    }
                    else
                    {
                        throw new Exception("Valor de Obra Complementaria ya existe");
                    }
                }
                else
                {
                    var response = await _valorObraComplementariaRepository.Create(entidad);
                    return _mapper.Map<ValorObraComplementariaDto>(response);
                }
            }
            else
            {
                var response = await _valorObraComplementariaRepository.Edit(entidad.Id, entidad);
                return _mapper.Map<ValorObraComplementariaDto>(response);
            }
        }

        public async Task<ValorObraComplementariaDto?> Disable(int id)
        {
            var response = await _valorObraComplementariaRepository.Disable(id);

            return _mapper.Map<ValorObraComplementariaDto>(response);
        }

        public async Task<ValorObraComplementariaDto> ObtenerAsync(int idValorObraComplementariaDto)
        {
            var entidad = await _valorObraComplementariaRepository.Find(idValorObraComplementariaDto);

            return _mapper.Map<ValorObraComplementariaDto>(entidad);
        }

        public async Task<ResponsePagination<ValorObraComplementariaDto>> PaginatedSearch(RequestPagination<ValorObraComplementariaDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<ValorObraComplementaria>>(dto);
            var response = await _valorObraComplementariaRepository.PaginatedSearch(entity);
            return _mapper.Map<ResponsePagination<ValorObraComplementariaDto>>(response);
        }
    }
}
