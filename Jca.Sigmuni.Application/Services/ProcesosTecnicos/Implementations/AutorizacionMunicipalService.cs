using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.AutorizacionesMunicipales;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class AutorizacionMunicipalService : IAutorizacionMunicipalService
    {
        private readonly IAutorizacionMunicipalRepository _autorizacionMunicipalRepository;

        public AutorizacionMunicipalService(
                                             IAutorizacionMunicipalRepository autorizacionMunicipalRepository
                                            )
        {
            _autorizacionMunicipalRepository = autorizacionMunicipalRepository;
        }

        public async Task<int> CrearAsync(AutorizacionMunicipalDto peticion)
        {
           

            var idGiroAutorizado = default(int?);
            if (peticion.GiroAutorizado != null)
            {
                idGiroAutorizado = peticion.GiroAutorizado.IdGiroAutorizado != 0 ? peticion.GiroAutorizado.IdGiroAutorizado : new int?();
            }

            var idActividadVerificada = default(int?);
            if (peticion.ActividadVerificada != null)
            {
                idActividadVerificada = peticion.ActividadVerificada.IdActividadVerificada != 0 ? peticion.ActividadVerificada.IdActividadVerificada : new int?();
            }

            var autorizacionMunicipal = new AutorizacionMunicipal
            {
                IdGiroAutorizado = idGiroAutorizado,
                IdActividadVerificada = idActividadVerificada,
                IdFicha = peticion.IdFicha
            };

            var response = await _autorizacionMunicipalRepository.Create(autorizacionMunicipal);
            //await _autorizacionMunicipalRepository.UnidadDeTrabajo.GuardarCambiosAsync();

            return response.IdGiroAutorizado ?? 0;
        }

        public async Task<bool> EliminarPorIdFichaAsync(int idFicha)
        {
            var lista = await _autorizacionMunicipalRepository.ListarPorIdFichaAsync(idFicha);
            var response = false;

            foreach (var item in lista)
            {
                response = await _autorizacionMunicipalRepository.EliminarAsync(item.IdAutMunicipal);
            }

            return response;
        }
    }
}
