using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ExoneracionPredios;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class ExoneracionPredioService : IExoneracionPredioService
    {
        private readonly IMapper _mapper;
        private readonly IExoneracionPredioRepository _exoneracionPredioRepository;
        private readonly ICaracteristicaTitularidadRepository _caracteristicaTitularidadRepository;

        public ExoneracionPredioService(IMapper mapper,
                                        IExoneracionPredioRepository exoneracionPredioRepository,
                                        ICaracteristicaTitularidadRepository caracteristicaTitularidadRepository)
        {
            _mapper = mapper;
            _exoneracionPredioRepository = exoneracionPredioRepository;
            _caracteristicaTitularidadRepository = caracteristicaTitularidadRepository;
        }

        public async Task<ExoneracionPredio?> CrearOActualizarAsync(ExoneracionPredioDto peticion)
        {
            var exoneracionPredio = await _exoneracionPredioRepository.Find(peticion.IdExoneracionPredio);

            if (exoneracionPredio == null)
            {
                exoneracionPredio = new ExoneracionPredio();
            }

            //var idCondicionEspecialPredio = default(int?);


            //int? idCondicionEspecialPredio = !string.IsNullOrWhiteSpace(peticion.IdCondicionEspecialPredio) ? RijndaelUtilitario.DecryptRijndaelFromUrl<int>(peticion.IdCondicionEspecialPredio) : null;

            //if (peticion.CondicionEspecialPredio != null)
            //{
            //    idCondicionEspecialPredio = !string.IsNullOrWhiteSpace(peticion.CondicionEspecialPredio.Id) ? RijndaelUtilitario.DecryptRijndaelFromUrl<int>(peticion.CondicionEspecialPredio.Id) : null;

            //    //idCondicionEspecialPredio = RijndaelUtilitario.DecryptRijndaelFromUrl<int>(peticion.CondicionEspecialPredio.Id);

            //}

            exoneracionPredio.NumeroResolucion = peticion.NumeroResolucion;
            exoneracionPredio.AnioResolucion = peticion.AnioResolucion;
            exoneracionPredio.Porcentaje = peticion.Porcentaje;
            exoneracionPredio.FechaInicio = peticion.FechaInicio;
            exoneracionPredio.FechaVencimiento = peticion.FechaVencimiento;
            exoneracionPredio.IdCondicionEspecialPredio = peticion.CondicionEspecialPredio?.IdCondicionEspecialPredio != 0 ? peticion.CondicionEspecialPredio?.IdCondicionEspecialPredio : null;

            if (exoneracionPredio.IdExoneracionPredio == 0)
            {
                return await _exoneracionPredioRepository.Create(exoneracionPredio);
            }
            else
            {
                return await _exoneracionPredioRepository.Edit(exoneracionPredio.IdExoneracionPredio, exoneracionPredio);
            }

            //var caracteristicaTitularidad = await _caracteristicaTitularidadRepository.Find(peticion.IdCaracteristicaTitularidad);

            //if (caracteristicaTitularidad != null)
            //{
            //    caracteristicaTitularidad.IdExoneracionPredio = exoneracionPredio.Id;

            //    _caracteristicaTitularidadRepositorio.Editar(caracteristicaTitularidad);

            //    await _caracteristicaTitularidadRepositorio.UnidadDeTrabajo.GuardarCambiosAsync();
            //}

            //return new OperacionDto<RespuestaSimpleDto<string>>(
            //    new RespuestaSimpleDto<string>()
            //    {
            //        Id = RijndaelUtilitario.EncryptRijndaelToUrl(exoneracionPredio.Id),
            //        Mensaje = "Se guardó con éxito."
            //    });
        }
    }
}
