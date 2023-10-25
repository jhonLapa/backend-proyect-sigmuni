using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.Lotes;
using Jca.Sigmuni.Application.Dtos.General.Manzanas;
using Jca.Sigmuni.Application.Dtos.General.Personas;
using Jca.Sigmuni.Application.Dtos.General.Sectores;
using Jca.Sigmuni.Application.Dtos.General.Ubigeos;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Construcciones;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Implementations;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class LoteService : ILoteService
    {
        private readonly IMapper _mapper;
        private readonly ILoteRepository _loteRepository;
        private readonly IConstruccionRepository _construccionRepository;

        public LoteService(IMapper mapper, ILoteRepository loteRepository, IConstruccionRepository construccionRepository)
        {
            _mapper = mapper;
            _loteRepository = loteRepository;
            _construccionRepository = construccionRepository;
    }
        public async Task<IList<LoteDto>> FindAll()
        {
            var response = await _loteRepository.FindAll();
            return _mapper.Map<IList<LoteDto>>(response);
        }

        public async Task<LoteDto?> Find(string id)
        {
            var response = await _loteRepository.Find(id);

            return _mapper.Map<LoteDto>(response);
        }

        public async Task<ResponsePagination<LoteDto>> PaginatedSearch(RequestPagination<LoteFormDto> dto)
        {
            var lfdto = new RequestPagination<LoteDto>() {
                Page = dto.Page,
                PerPage = dto.PerPage,
            };
            if (dto.Filter != null)
            {
                lfdto.Filter = new LoteDto()
                { Codigo = dto.Filter?.CodigoLote,
                    Manzana = new ManzanaDto()
                    { Codigo = dto.Filter?.CodigoManzana, Sector = new SectorDto() { Codigo = dto.Filter?.CodigoSector, Ubigeo = new UbigeoDto() { Codigo = dto.Filter?.CodigoUbigeo } } },
                    Estado = dto.Filter?.Estado
                };
            }
            var entity = _mapper.Map<RequestPagination<Lote>>(lfdto);
            var response = await _loteRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<LoteDto>>(response);
        }
        //public async Task<LoteDetalleDto> ObtenerCabeceraPorLote(string idLoteCarto)
        //{

        //    var cabecera = await _loteRepository.ObtenerCabeceraPorLote(idLoteCarto);
        //    //var detalle = await _loteRepository.ObtenerDetallePorLote(idLoteCarto);
        //    //var construccion = await _construccionRepositorio.BuscarPorIdLoteCartografiaAsync(idLoteCarto);
        //    //var contruccionList = _mapper.Map<List<ConstruccionDto>>(construccion);
        //    //cabecera.LoteDetalle = detalle;

        //    var dto = _mapper.Map<LoteDetalleDto>(cabecera);
        //    //dto.Construccion = contruccionList;

        //    return _mapper.Map<LoteDetalleDto>(dto);
        //}

        public async Task<LoteDetalleDto> ObtenerDatosPorLote(string idLoteCarto)
        {
            var cabecera = await _loteRepository.ObtenerCabeceraPorLote(idLoteCarto);
            var construccion = await _construccionRepository.BuscarPorIdLoteCartografiaAsync(idLoteCarto);
            var contruccionList = _mapper.Map<List<ConstruccionDto>>(construccion);

            var dto = _mapper.Map<LoteDetalleDto>(cabecera);
            dto.Construccion = contruccionList;

            return _mapper.Map<LoteDetalleDto>(dto);
        }
    }
}
