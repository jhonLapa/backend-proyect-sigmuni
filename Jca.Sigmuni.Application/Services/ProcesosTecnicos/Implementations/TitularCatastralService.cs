using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TitularCatastrales;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class TitularCatastralService : ITitularCatastralService
    {
        private readonly IMapper _mapper;
        private readonly ITitularCatastralRepository _titularCatastralRepository;
        private readonly IDependienteService _dependienteService;

        public TitularCatastralService(IMapper mapper,
                                       ITitularCatastralRepository titularCatastralRepository,
                                       IDependienteService dependienteService)
        {
            _mapper = mapper;
            _titularCatastralRepository = titularCatastralRepository;
            _dependienteService = dependienteService;
        }

        public async Task<TitularCatastral?> CrearCotitularAsync(PersonaTitularDto peticion)
        {
            var titularCatastral = await _titularCatastralRepository.BuscarPorIdFichaYIdCaracteristicaTitularidadAsync(peticion.IdFicha, peticion.IdCaracteristicaTitularidad);
            if (titularCatastral == null)
            {
                titularCatastral = new TitularCatastral();
            }

            titularCatastral.IdPersona = null;
            titularCatastral.IdFicha = peticion.IdFicha;
            titularCatastral.IdCaracteristicaTitularidad = peticion.IdCaracteristicaTitularidad;

            if (titularCatastral.IdTitularCatastral == 0)
            {
                return await _titularCatastralRepository.Create(titularCatastral);
            }
            else
            {
                return await _titularCatastralRepository.Edit(titularCatastral.IdTitularCatastral, titularCatastral);
            }
        }

        public async Task<bool> EliminarCotitularAsync(PersonaTitularDto peticion)
        {
            var titularCatastral = await _titularCatastralRepository.BuscarPorIdFichaYIdCaracteristicaTitularidadAsync(peticion.IdFicha, peticion.IdCaracteristicaTitularidad);

            if (titularCatastral == null)
            {
                //return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, "No existe registro");
                return false;
            }

            return await _titularCatastralRepository.EliminarAsync(titularCatastral.IdTitularCatastral);
        }

        public async Task<TitularCatastral?> GuardarPersonaTitularAsync(PersonaTitularDto peticion)
        {
            //if (string.IsNullOrEmpty(peticion.IdPersona) return new OperacionDto<RespuestaSimpleDto<long>>(CodigosOperacionDto.Invalido, "No ha ingresado el titular del predio.");

            var idTitularCatastral = peticion.IdTitularCatastral;
            var titularCatastral = await _titularCatastralRepository.Find(idTitularCatastral);
            if (titularCatastral == null) titularCatastral = new TitularCatastral();

            titularCatastral.IdPersona = peticion.IdPersona;
            titularCatastral.IdFicha = peticion.IdFicha;
            titularCatastral.IdCaracteristicaTitularidad = peticion.IdCaracteristicaTitularidad;
            titularCatastral.CodContribuyente = peticion.CodigoContribuyente;
            titularCatastral.NumTitularidad = peticion.NumTitularidad;

            TitularCatastral? responseTitularCatastral;

            if (titularCatastral.IdTitularCatastral == 0) responseTitularCatastral = await _titularCatastralRepository.Create(titularCatastral);
            else responseTitularCatastral = await _titularCatastralRepository.Edit(titularCatastral.IdTitularCatastral, titularCatastral);

            //var idDependiente = default(int);
            //if (titularCatastral.Dependientes?.Count > 0)
            //{
            //    idDependiente = titularCatastral.Dependientes.FirstOrDefault().Id;
            //}

            //if (peticion.Conyuge != null)
            //{
            //    peticion.Conyuge.IdConyugue = idDependiente;
            //    peticion.Conyuge.IdTitularCatastral = titularCatastral.IdTitularCatastral;
            //    await _dependienteService.GuardaronyugeTitularAsync(peticion.Conyuge);
            //}

            return responseTitularCatastral;
        }

        public async Task<bool> EliminarTitularCatastralAsync(int idTitularCatsatral)
        {
            var entidad = await _titularCatastralRepository.BuscarPorIdAsync(idTitularCatsatral);
            if (entidad == null)
            {
                return false;
            }
            var response = false;
            response =  await _titularCatastralRepository.EliminarAsync(entidad.IdTitularCatastral);
            

            return response;
        }
    }
}
