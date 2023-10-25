using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.AreaActividadesEconomicas;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class AreaActividadEconomicaService : IAreaActividadEconomicaService
    {
        private readonly IAreaActividadEconomicaRepository _areaActividadEconomicaRepository;

        public AreaActividadEconomicaService(
                                              IAreaActividadEconomicaRepository areaActividadEconomicaRepository
                                             )
        {
            _areaActividadEconomicaRepository = areaActividadEconomicaRepository;
        }

        public async Task<int> CrearOActualizarAsync(AreaActividadEconomicaDto peticion)
        {
            

            var id = peticion.IdAreaActividadEconomica;
            var areaActividadEconomica = await _areaActividadEconomicaRepository.BuscarPorIdAsync(id);

            if (areaActividadEconomica == null)
            {
                areaActividadEconomica = new AreaActividadEconomica();
            }

            areaActividadEconomica.PredioCatAutorizada = peticion.PredioCatAutorizada;
            areaActividadEconomica.ViaPubAutorizada = peticion.ViaPubAutorizada;
            areaActividadEconomica.BienComunAutorizada = peticion.BienComunAutorizada;
            areaActividadEconomica.TotalAutorizada = (peticion.PredioCatAutorizada.HasValue ? peticion.PredioCatAutorizada.Value : 0) + (peticion.ViaPubAutorizada.HasValue ? peticion.ViaPubAutorizada.Value : 0) + (peticion.BienComunAutorizada.HasValue ? peticion.BienComunAutorizada.Value : 0);

            areaActividadEconomica.PredioCatVerificada = peticion.PredioCatVerificada;
            areaActividadEconomica.ViaPubVerificada = peticion.ViaPubVerificada;
            areaActividadEconomica.BienComunVerificada = peticion.BienComunVerificada;
            areaActividadEconomica.TotalVerificada = (peticion.PredioCatVerificada.HasValue ? peticion.PredioCatVerificada.Value : 0) + (peticion.ViaPubVerificada.HasValue ? peticion.ViaPubVerificada.Value : 0) + (peticion.BienComunVerificada.HasValue ? peticion.BienComunVerificada.Value : 0);

            areaActividadEconomica.NumExpediente = peticion.NumExpediente;
            areaActividadEconomica.NumLicencia = peticion.NumLicencia;
            areaActividadEconomica.FechaExpedicion = peticion.FechaExpedicion;
            areaActividadEconomica.FechaVencimiento = peticion.FechaVencimiento;
            areaActividadEconomica.InicioActividad = peticion.InicioActividad;
            areaActividadEconomica.NumResolucion = peticion.NumResolucion;
            areaActividadEconomica.CodCatAsigCorrect = peticion.CodCatAsigCorrect;
            areaActividadEconomica.AnioAutorizacion = peticion.AnioAutorizacion;
            areaActividadEconomica.IdFicha = peticion.IdFicha;

            var response = 0;
            if (areaActividadEconomica.IdAreaActividadEconomica == 0)
            {
              var entity =  await _areaActividadEconomicaRepository.Create(areaActividadEconomica);
                response = entity.IdAreaActividadEconomica;
            }
            else
            {
                var entity = await _areaActividadEconomicaRepository.Edit(areaActividadEconomica.IdAreaActividadEconomica,areaActividadEconomica);
                response = entity.IdAreaActividadEconomica;
            }

           // await _areaActividadEconomicaRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();

            return response;
        }
    }
}
