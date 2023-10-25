using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CaracteristicaTitularidades;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class CaracteristicaTitularidadService : ICaracteristicaTitularidadService
    {
        private readonly IMapper _mapper;
        private readonly ICaracteristicaTitularidadRepository _caracteristicaTitularidadRepository;
        private readonly IExoneracionPredioService _exoneracionPredioService;

        public CaracteristicaTitularidadService(IMapper mapper,
                                                ICaracteristicaTitularidadRepository caracteristicaTitularidadRepository,
                                                IExoneracionPredioService exoneracionPredioService)
        {
            _mapper = mapper;
            _caracteristicaTitularidadRepository = caracteristicaTitularidadRepository;
            _exoneracionPredioService = exoneracionPredioService;
        }

        public async Task<CaracteristicaTitularidad?> CrearOActualizarAsync(CaracteristicaTitularidadDto peticion)
        {
            var id = peticion.IdCaracteristicaTitularidad;

            var caracteristicaTitularidad = await _caracteristicaTitularidadRepository.Find(id);

            if (caracteristicaTitularidad == null)
            {
                caracteristicaTitularidad = new CaracteristicaTitularidad();
            }

            var idCondicionTitular = new int?();

            if (peticion.CondicionTitular != null)
            {
                idCondicionTitular = peticion.CondicionTitular.IdCondicionTitular != 0 || peticion.CondicionTitular.IdCondicionTitular != null ? peticion.CondicionTitular.IdCondicionTitular : new int?();
            }

            var idFormaAdquisicion = new int?();

            if (peticion.FormaAdquisicion != null)
            {
                idFormaAdquisicion = peticion.FormaAdquisicion.IdFormaAdquisicion != 0 || peticion.FormaAdquisicion.IdFormaAdquisicion != null ? peticion.FormaAdquisicion.IdFormaAdquisicion : new int?();
            }

            //var exoneracionPredioId = new int?();

            //if (peticion.ExoneracionPredioId != null)
            //{
            //    exoneracionPredioId = !string.IsNullOrWhiteSpace(peticion.ExoneracionPredio.Id) ? RijndaelUtilitario.DecryptRijndaelFromUrl<int>(peticion.ExoneracionPredio.Id) : new int?();
            //}

            int? exoneracionPredioId = peticion.IdExoneracionPredio;

            if (peticion.ExoneracionPredio != null)
            {
                var exoneracionPredio = await _exoneracionPredioService.CrearOActualizarAsync(peticion.ExoneracionPredio);

                if (exoneracionPredio != null) exoneracionPredioId = exoneracionPredio?.IdExoneracionPredio;
                //exoneracionPredioId = peticion.ExoneracionPredio.IdExoneracionPredio;

            }

            caracteristicaTitularidad.IdCondicionTitular = idCondicionTitular;
            caracteristicaTitularidad.IdFormaAdquisicion = idFormaAdquisicion;
            caracteristicaTitularidad.FechaAdquisicion = peticion.FechaAdquisicion;
            caracteristicaTitularidad.FormaAdquisicionOtros = peticion.FormaAdquisicionOtros;
            caracteristicaTitularidad.CondicionTitularOtros = peticion.CondicionTitularOtros;
            caracteristicaTitularidad.PorcentajeTitularidad = peticion.PorcentajeTitularidad;
            caracteristicaTitularidad.IdExoneracionPredio = exoneracionPredioId;
            //if (exoneracionPredioId != 0 || exoneracionPredioId != null)
            //{
            //    caracteristicaTitularidad.IdExoneracionPredio = exoneracionPredioId;
            //}
            //else
            //{
            //    caracteristicaTitularidad.IdExoneracionPredio = null;
            //};

            if (caracteristicaTitularidad.IdCaracteristicaTitularidad == 0)
            {
                return await _caracteristicaTitularidadRepository.Create(caracteristicaTitularidad);
            }
            else
            {
                return await _caracteristicaTitularidadRepository.Edit(caracteristicaTitularidad.IdCaracteristicaTitularidad, caracteristicaTitularidad);
            }
        }

        public async Task<bool> EliminarAsync(int idCaracteristicaTitularidad)
        {
            var caracteristicaTitularidad = await _caracteristicaTitularidadRepository.Find(idCaracteristicaTitularidad);

            if (caracteristicaTitularidad == null)
            {
                return false;
            }
            var response = false;
            response = await _caracteristicaTitularidadRepository.EliminarAsync(caracteristicaTitularidad.IdCaracteristicaTitularidad);
            


            return response;
        }

    }
}
