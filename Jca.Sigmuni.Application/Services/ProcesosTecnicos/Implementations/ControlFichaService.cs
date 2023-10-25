using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.UnidadesCatastrales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ControlFichas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Domain.ProcesosTecnicos.Enums;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abastractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Util.Flags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public partial class ControlFichaService : IControlFichaService
    {
        private readonly IMapper _mapper;
        private readonly IFichaService _fichaService;
        private readonly IFichaRepository _fichaRepository;
        private readonly IUnidadCatastralService _unidadCatastralService;
        private readonly IControlFichaRepository _controlFichaRepository;
        private readonly IConstruccionService _construccionService;
        public ControlFichaService(IMapper mapper, 
                                   IControlFichaRepository controlFichaRepository,
                                   IFichaService fichaService,
                                   IFichaRepository fichaRepository,
                                   IUnidadCatastralService unidadCatastralService,
                                   IConstruccionService construccionService)
        {
            _mapper = mapper;
            _controlFichaRepository = controlFichaRepository;
            _fichaService = fichaService;
            _fichaRepository = fichaRepository;
            _unidadCatastralService = unidadCatastralService;
            _construccionService = construccionService;
        }

        public async Task<List<ControlFichaDto>> ControlFichasPorIdFicha(int idFicha)
        {
            List<ControlFichaDto> controlFichas = new List<ControlFichaDto>();

            var responseDinamica = await _fichaService.FichaIndividualPorIdAsync(idFicha);
            if (responseDinamica == null) throw new Exception("No se encontro la ficha individual dinamica");
            var dinamica = responseDinamica;

            var responseEstatica = await _fichaService.FichaIndividualPorIdAsync(dinamica.Ficha?.IdFichaIndividualEstatica ?? 0);
            if (responseEstatica == null) throw new Exception("No se encontro la ficha individual estatica");
            var estatica = responseEstatica;

            var controlFichasIndividual = ControlFichasIndividual(dinamica, estatica);
            if (controlFichasIndividual != null)
                controlFichas.AddRange(controlFichasIndividual);

            //CONTROL FICHA BIEN COMUN
            if (estatica?.Ficha?.IdFichaPadre != 0 && estatica?.Ficha?.IdFichaPadre != null)
            {
                var controlFichasBienComun = await ControlFichasBienComunPorIdFicha((int)dinamica.Ficha.IdFichaPadre, (int)estatica.Ficha.IdFichaPadre);
                if (controlFichasBienComun != null)
                    controlFichas.AddRange(controlFichasBienComun);
            }
            //CONTROL FICHA BIEN CULTURAL
            if (estatica?.Ficha?.IdFichaBienCultural != 0 && estatica?.Ficha?.IdFichaBienCultural != null)
            {
                var controlFichasBienCultural = await ControlFichasBienCulturalPorIdFicha(dinamica.Ficha.IdFichaBienCultural, estatica.Ficha.IdFichaBienCultural);
                if (controlFichasBienCultural != null)
                    controlFichas.AddRange(controlFichasBienCultural);
            }
            //CONTROL FICHA COTITULAR
            if (estatica?.Ficha?.IdFichaCotitular != 0 && estatica?.Ficha?.IdFichaCotitular != null)
            {
                var controlFichasCotitular = await ControlFichasCotitularPorIdFicha(dinamica.Ficha.IdFichaCotitular, estatica.Ficha.IdFichaCotitular);
                if (controlFichasCotitular != null)
                    controlFichas.AddRange(controlFichasCotitular);
            }
            //CONTROL FICHA ECONÓMICA //PASAR LISTA DE IDS
            if (estatica?.Ficha?.IdsFichasEconomicas?.Count > 0)
            {
                var controlFichasEconomicas = await ControlFichasEconomicasPorIdsFicha(dinamica.Ficha.IdsFichasEconomicas, estatica.Ficha.IdsFichasEconomicas);
                if (controlFichasEconomicas != null)
                    controlFichas.AddRange(controlFichasEconomicas);
            }

            return controlFichas;
        }

        public async Task<bool> FichaControlConfirmAsync(int idFicha)
        {
            var ficha = await _fichaRepository.Find(idFicha);
            var FichasAsociadas = await _fichaRepository.BuscarPorIdUnidadCatrastalAsync(ficha.IdUnidadCatastral);
            var sinDinamico = true;
            for(int i = 0; i < FichasAsociadas.Count; i++)
            {
                var f = FichasAsociadas[i];
                if(f.Estado == (int)EstadoFicha.Estatico)
                {
                    f.Estado = (int)EstadoFicha.Historico;
                    await _fichaRepository.Edit(f.IdFicha, f);
                }
            }
            ficha.Estado = (int)EstadoFicha.Estatico;
            await _fichaRepository.Edit(ficha.IdFicha, ficha);

            await _construccionService.CalcularValorizacionAsync(ficha);

            var fichasXLote = await _fichaRepository.BuscarPorIdLoteCartoYIdTipoAsync(ficha.IdLoteCarto, (int)TipoFichaEnum.Individual);
            fichasXLote.ForEach(f =>
            {
                if (f.Estado == (int)EstadoFicha.Dinamico)
                {
                    sinDinamico = false;

                }
            });

            if (sinDinamico == true)
            {
                for (int i = 0; i < fichasXLote.Count; i++)
                {
                    UnidadCatastralDto unidad = new UnidadCatastralDto();
                    unidad.IdLoteCarto = fichasXLote[i].UnidadCatastral.IdLoteCarto;
                    unidad.CodigoHojaCatastral = fichasXLote[i].UnidadCatastral.CodigoHojaCatastral;
                    //unidad.Motivo.Id = RijndaelUtilitario.EncryptRijndaelToUrl(fichasXLote[i].UnidadCatastral.IdMotivo);
                    unidad.CodigoCatastral = fichasXLote[i].UnidadCatastral.CodigoCatastral;
                    unidad.CodigoPredialSat = fichasXLote[i].UnidadCatastral.CodigoPredialSat;
                    unidad.Correlativo = fichasXLote[i].UnidadCatastral.Correlativo;
                    unidad.Ambito = fichasXLote[i].UnidadCatastral.Ambito;
                    unidad.IdLoteCarto = fichasXLote[i].UnidadCatastral.IdLoteCarto;
                    unidad.AnioUltimoDDJJ = fichasXLote[i].UnidadCatastral.AnioUltimoDDJJ;
                    unidad.IdUnidadCatastral = fichasXLote[i].UnidadCatastral.IdUnidadCatastral;
                    await _unidadCatastralService.ActualizarAsync(unidad);
                }

            }

            return true;
        }

        public async Task<bool> GuardarControlFichaAsync(List<ControlFichaDto> controlesFichas, bool esDirivarCC = false)
        {
            foreach (var peticion in controlesFichas)
            {
                if (peticion.IdFicha == 0 || peticion.IdFicha == null)
                    throw new Exception("Ficha es necesario");
                if (peticion.IdUnidadCatastral == 0 || peticion.IdUnidadCatastral == null)
                    throw new Exception("Unidad catastral es necesario");

                ControlFicha? entidad = null;
                var idFicha = peticion.IdFicha;
                var idUnidadCatastral = peticion.IdUnidadCatastral;

                if (peticion.Id != 0 && peticion.Id != null)
                {
                    var id = peticion.Id;
                    entidad = await _controlFichaRepository.Find(id ?? 0);
                }
                else
                {
                    var peticionControl = new ControlFicha()
                    {
                        IdFicha = (int)idFicha,
                        NombreTab = peticion.NombreTab,
                        NombreCampo = peticion.NombreCampo
                    };
                    entidad = await _controlFichaRepository.BuscarPorControlFicha(peticionControl);
                }

                if (entidad == null)
                    entidad = new ControlFicha();

                var idUsuario = peticion.IdUsuario;

                entidad.IdFicha = (int)idFicha;
                entidad.IdUnidadCatastral = (int)idUnidadCatastral;
                entidad.NombreCampo = peticion.NombreCampo;
                entidad.NombreFicha = peticion.NombreFicha;
                entidad.NombreTab = peticion.NombreTab;
                entidad.ValorAnterior = peticion.ValorAnterior;
                entidad.ValorActual = peticion.ValorActual;
                entidad.FechaActualizacion = DateTime.Now;
                //entidad.idUsuario = idUsuario;
                if (!esDirivarCC)
                {
                    entidad.EsConforme = peticion.EsConforme;
                    entidad.Observacion = peticion.Observacion;
                }

                if (entidad.Id == 0) await _controlFichaRepository.Create(entidad);
                else await _controlFichaRepository.Edit(entidad.Id, entidad);
            }

            return true;
        }

        public async Task<bool> GuardarDerivarControlFichaAsync(int idFicha)
        {
            var responseControlFichas = await ControlFichasPorIdFicha(idFicha);
            if (responseControlFichas.Count == 0 || responseControlFichas == null) throw new Exception("La operacion no se pudo completar");

            var responseGuardar = await GuardarControlFichaAsync(responseControlFichas, true);

            return responseGuardar;
        }

        public async Task<List<ControlFichaDto>> ListadoFichasAsociadasPorIdFichaAsync(int idFicha)
        {
            List<ControlFichaDto> controlFichas = new List<ControlFichaDto>();

            var ficha = await _fichaRepository.FindByIdAsync(idFicha);

            if (ficha == null) throw new Exception("No se encontro la ficha individual");

            var listaIndividual = await _controlFichaRepository.BuscarPorIdFichaAsync(idFicha);
            if (listaIndividual == null) throw new Exception("Control Ficha no existe");

            var dtoIndividual = _mapper.Map<List<ControlFichaDto>>(listaIndividual);
            controlFichas.AddRange(dtoIndividual);


            var fichasAsociadas = await _fichaRepository.BuscarPorIdFichaPadreYEstadoFichaAsync(ficha.IdFicha, ficha.Estado);
            if (fichasAsociadas.Count > 0)
            {
                List<int> listaIds = new List<int>();
                fichasAsociadas.ForEach(async f =>
                {
                    if (f.IdTipoFicha == (int)TipoFichaEnum.Cotitular)
                    {
                        var responseCotitular = await ListadoPorIdFichaAsync(f.IdFicha);
                        if (responseCotitular != null) controlFichas.AddRange(responseCotitular);
                    }

                    if (f.IdTipoFicha == (int)TipoFichaEnum.ActividadEconomica)
                    {
                        listaIds.Add(f.IdFicha);
                    }

                    if (f.IdTipoFicha == (int)TipoFichaEnum.BienesCulturales)
                    {
                        var responseBienCultural = await ListadoPorIdFichaAsync(f.IdFicha);
                        if (responseBienCultural != null) controlFichas.AddRange(responseBienCultural);
                    }
                });

                listaIds.ForEach(async idEconomica =>
                {
                    var responseEconomica = await ListadoPorIdFichaAsync(idEconomica);
                    if (responseEconomica != null) controlFichas.AddRange(responseEconomica);
                });
            }

            if (ficha.IdFichaPadre != null && ficha.IdFichaPadre != 0)
            {
                var responseBienComun = await ListadoPorIdFichaAsync(ficha.IdFichaPadre ?? 0);
                if (responseBienComun != null) controlFichas.AddRange(responseBienComun);
            }

            return controlFichas;
        }

        public async Task<List<ControlFichaDto>> ListadoPorIdFichaAsync(int idFicha)
        {
            var entidad = await _controlFichaRepository.BuscarPorIdFichaAsync(idFicha);

            if (entidad == null) throw new Exception("Control Ficha no existe");
            var dto = _mapper.Map<List<ControlFichaDto>>(entidad);
            return dto;
        }

        public async Task<List<ControlFichaDto>> ListadoPorIdUnidadCatastralAsync(int idUnidadCatastral)
        {
            var entidad = await _controlFichaRepository.BuscarPorIdUnidadCatastralAsync(idUnidadCatastral);

            if (entidad == null)
            {
                throw new Exception("Control Ficha no existe");
            }

            var dto = _mapper.Map<List<ControlFichaDto>>(entidad);
            return dto;
        }

        public async Task<ControlFichaDto> ObtenerPorIdAsync(int idControlFicha)
        {
            var entidad = await _controlFichaRepository.Find(idControlFicha);

            if (entidad == null)
            {
                throw new Exception("Control Ficha no existe");
            }

            var dto = _mapper.Map<ControlFichaDto>(entidad);
            return dto;
        }
    }
}
