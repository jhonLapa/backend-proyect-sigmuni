using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.UnidadesCatastrales;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class UnidadCatastralService : IUnidadCatastralService
    {

        private readonly IMapper _mapper;
        private readonly IUnidadCatastralRepository _unidadCatastralRepository;
        private readonly ILoteRepository _loteRepository;

        public UnidadCatastralService(IMapper mapper, IUnidadCatastralRepository unidadCatastralRepository, ILoteRepository loteRepository)
        {
            _mapper = mapper;
            _unidadCatastralRepository = unidadCatastralRepository;
            _loteRepository = loteRepository;
        }

        public async Task<int> ActualizarAsync(UnidadCatastralDto peticion)
        {
            if (peticion.IdUnidadCatastral == 0 || peticion?.IdUnidadCatastral == null)
            {
                throw new Exception("El id unidad catastral es requerido");
            }

            var unidad = await _unidadCatastralRepository.Find(peticion.IdUnidadCatastral);

            if (unidad == null)
            {
                throw new Exception("El registro unidad catastral no existe");
            }

            var lote = await _loteRepository.Find(peticion.IdLoteCarto);

            if (lote == null)
            {
                throw new Exception("El lote ingresado no existe, verifique por favor");
            }

            //var idMotivo = new long?();
            //if (peticion.Motivo != null)
            //{
            //    idMotivo = !string.IsNullOrWhiteSpace(peticion.Motivo.Id) ? RijndaelUtilitario.DecryptRijndaelFromUrl<int>(peticion.Motivo.Id) : new long?();
            //}
            var unidadCUCMAX = await _unidadCatastralRepository.MaximoCUCAsync(peticion.IdLoteCarto);
            long numberCuc = 0;
            if (unidadCUCMAX != null)
            {
                if (unidadCUCMAX.CodigoCatastral != null)
                {
                    var numeroCuc = Convert.ToInt64(unidadCUCMAX.CodigoCatastral);
                    numberCuc = numeroCuc + 1;
                }
                else
                {
                    var CucLote = await _loteRepository.BuscarCucMaximo();
                    var numeroCuc = Convert.ToInt64(CucLote.CUC) * 1000;
                    numberCuc = numeroCuc + 1;
                }
            }
            //unidad.IdMotivo = idMotivo;
            unidad.CodigoCatastral = peticion.CodigoCatastral;
            unidad.CodigoHojaCatastral = peticion.CodigoHojaCatastral;
            unidad.CodigoPredialSat = peticion.CodigoPredialSat;
            unidad.Correlativo = peticion.Correlativo;
            //unidad.CUC = numberCuc.ToString();
            unidad.Ambito = peticion.Ambito;
            unidad.IdLoteCarto = peticion.IdLoteCarto;
            unidad.AnioUltimoDDJJ = peticion.AnioUltimoDDJJ;


            await _unidadCatastralRepository.Edit(unidad.IdUnidadCatastral, unidad);

            return unidad.IdUnidadCatastral;
        }

        public async Task<UnidadCatastralDto> Create(UnidadCatastralFormDto dto)
        {
            var correlativo = $"0001";

            var unidades = await _unidadCatastralRepository.ObtenerPorIdLoteCartoAsync(dto.IdLoteCarto);
            if (unidades != null || unidades?.Count > 0)
            {
                var UltimoUnidad = unidades.Where(e => e.IdUnidadCatastral == unidades.Max(e => e.IdUnidadCatastral)).FirstOrDefault();
                if (UltimoUnidad != null)
                {
                    var nroCorrelativo = Convert.ToInt32(!string.IsNullOrWhiteSpace(UltimoUnidad.Correlativo) ? UltimoUnidad.Correlativo : "0");
                    var cod = $"0000{nroCorrelativo + 1}";
                    cod = cod.Substring(cod.Length - 4);
                    correlativo = cod;
                }
            }

            var unidad = new UnidadCatastral();

            unidad.CodigoCatastral = dto.CodigoCatastral;
            unidad.CodigoHojaCatastral = dto.CodigoHojaCatastral;
            unidad.CodigoPredialSat = dto.CodigoPredialSat;
            unidad.UnidadAcumuladaCodigo = dto.UnidadAcumuladaCodigo;
            unidad.Correlativo = correlativo;
            unidad.Ambito = dto.Ambito;
            unidad.IdLoteCarto = dto.IdLoteCarto;
            unidad.AnioUltimoDDJJ = dto.AnioUltimoDDJJ;
            unidad.IdMotivo = dto.IdMotivo == 0 ? null : dto.IdMotivo;

            var response = await _unidadCatastralRepository.Create(unidad);

            return _mapper.Map<UnidadCatastralDto>(response);
        }

        public Task<UnidadCatastralDto?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<UnidadCatastralDto>> FindAll()
        {
            var response = await _unidadCatastralRepository.FindAll();

            return _mapper.Map<IList<UnidadCatastralDto>>(response);
        }



    }
}
