using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Aranceles;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Depreciaciones;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.Vias.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class ArancelService : IArancelService
    {
        private readonly IMapper _mapper;
        private readonly ISectorRepository _sectorRepository;
        private readonly IManzanaRepository _manzanaRepository;
        private readonly IViaRepository _viaRepository;
        private readonly IArancelRepository _ArancelRepository;

        public ArancelService(
            IMapper mapper,
            ISectorRepository sectorRepository,
            IManzanaRepository manzanaRepository,
            IViaRepository viaRepository,
        IArancelRepository ArancelRepository

        )

        {
            _mapper = mapper;
            _ArancelRepository = ArancelRepository;
            _sectorRepository = sectorRepository;
            _manzanaRepository = manzanaRepository;
            _viaRepository = viaRepository;

        }
        public async Task<bool> CrearOActualizarAsync(ArancelDto peticion)
        {
            
            
            
            var entidad = await _ArancelRepository.Find(peticion.IdArancel);

            if (entidad == null)
                entidad = new Arancel();

            entidad.Anio = peticion.Anio;
            entidad.Valor = peticion.Valor;

            
            var sector = await _sectorRepository.BuscarPorCodigoAsync(peticion.CodSector);
            if (sector != null)
            {
                var manzana = await _manzanaRepository.BuscarPorIdSectorYCodManzanaAsync(sector.Id, peticion.CodManzana);
                if (manzana != null)
                {
                    entidad.IdManzana = manzana.Id;
                }
            }
            else
            {
                entidad.IdManzana = "";
            }


            var via = await _viaRepository.BuscarPorCodigoViaAsync(peticion.CodVia);
            if (via != null)
            {
                entidad.IdVia = via.IdVia;
            }
            else
            {
                entidad.IdVia = "";
            }

            entidad.Estado = peticion.Estado;

            var validar = await _ArancelRepository.BuscarPorIdManzanaIdViaAsync(entidad.IdManzana, entidad.IdVia);
            if (entidad.IdManzana != null && entidad.IdVia != null)
            {
                if (entidad.IdArancel == 0)
                {
                    if (validar != null)
                    {
                        return false;
                    }
                    else
                    {
                        await _ArancelRepository.Create(entidad);
                    }
                }
                else
                {
                    if (validar != null)
                    {

                        if (validar.IdArancel == entidad.IdArancel)
                        {
                            await _ArancelRepository.Edit(entidad.IdArancel , entidad);
                        }
                        else
                        {
                            return false;
                        }

                    }
                }
              

                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> CrearMasivoAsync(List<ArancelDto> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                var peticion = lista[i];
                


                var entidad = new Arancel();
                entidad.Anio = peticion.Anio;
                entidad.Valor = peticion.Valor;
                var sector = await _sectorRepository.BuscarPorCodigoAsync(peticion.CodSector);
                if (sector != null)
                {
                    var manzana = await _manzanaRepository.BuscarPorIdSectorYCodManzanaAsync(sector.Id, peticion.CodManzana);
                    if (manzana != null)
                    {
                        entidad.IdManzana = manzana.Id;
                    }
                }
                else
                {
                    entidad.IdManzana = null;
                }


                var via = await _viaRepository.BuscarPorCodigoViaAsync(peticion.CodVia);
                if (via != null)
                {
                    entidad.IdVia = via.IdVia;
                }
                else
                {
                    entidad.IdVia = null;
                }

                entidad.Estado = peticion.Estado;



                if (entidad.IdArancel == 0)
                {
                    var validar = await _ArancelRepository.BuscarPorIdManzanaIdViaAsync(entidad.IdManzana, entidad.IdVia);
                    if (validar != null)
                    {
                        if (validar.Estado == false)
                        {
                            validar.Estado = true;
                            await _ArancelRepository.Edit(validar.IdArancel,validar);
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        await _ArancelRepository.Create(entidad);
                    }
                }
                else
                {
                    await _ArancelRepository.Edit(entidad.IdArancel,entidad);
                }

                
            }

            return true;
        }
        public async Task<bool> EliminarAsync(int id)
        {
            

            var entidad = await _ArancelRepository.Find(id);
            if (entidad == null)
            {
                return false;
            }
            entidad.Estado = false;
            await _ArancelRepository.Edit(entidad.IdArancel, entidad);

            

            return true;
        }


        public async Task<List<ArancelDto>> FindAll()
        {
            var entidad = await _ArancelRepository.FindAll();

            var dto = _mapper.Map<List<ArancelDto>>(entidad);
            return dto;
        }
       

        public async Task<ArancelDto?> ObtenerAsync(int id)
        {
            
            var entidad = await _ArancelRepository.Find(id);
            if (entidad == null)
            {
                return null;
            }

            if (entidad.IdManzana != null)
            {
                var manzana = _manzanaRepository.BuscarPorIdCartoNoBorradoAsync(entidad.IdManzana);
                entidad.Manzana = manzana.Result;

            }
            if (entidad.IdVia != null)
            {
                var via = _viaRepository.BuscarPorIdYNoBorradoAsync(entidad.IdVia);
                entidad.Via = via.Result;

            }



            var dto = _mapper.Map<ArancelDto>(entidad);


            return dto;
        }


        public async Task<ResponsePagination<ArancelDto>> PaginatedSearch(RequestPagination<ArancelDto> dto)
        {
            

            var entity = _mapper.Map<RequestPagination<ArancelBusqueda>>(dto);
            var response = await _ArancelRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<ArancelDto>>(response);
        }

        
    }
}
