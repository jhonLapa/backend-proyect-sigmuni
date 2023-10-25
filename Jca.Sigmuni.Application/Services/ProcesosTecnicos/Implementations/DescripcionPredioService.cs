using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.DescripcionPredios;
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
    public class DescripcionPredioService : IDescripcionPredioService
    {
        private readonly IMapper _mapper;
        private readonly IDescripcionPredioRepository _descripcionPredioRepository;
        private readonly ILinderoPredioService _linderoPredioService;

        public DescripcionPredioService(IMapper mapper,
                                        IDescripcionPredioRepository descripcionPredioRepository,
                                        ILinderoPredioService linderoPredioService)
        {
            _mapper = mapper;
            _descripcionPredioRepository = descripcionPredioRepository;
            _linderoPredioService = linderoPredioService;
        }

        public async Task<DescripcionPredio?> CrearOActualizarAsync(DescripcionPredioDto peticion)
        {
            var id = peticion.IdDescripcionPredio;
            var descripcionPredio = await _descripcionPredioRepository.Find(id);

            if (descripcionPredio == null)
            {
                descripcionPredio = new DescripcionPredio();
            }

            var idClasificacionPredio = new int?();
            var idPredioCatastralEn = new int?();
            var idUsoPredio = new int?();

            if (peticion.ClasificacionPredio != null)
            {
                idClasificacionPredio = peticion.ClasificacionPredio.IdClasificacionPredio != 0 || peticion.ClasificacionPredio.IdClasificacionPredio != null ? peticion.ClasificacionPredio.IdClasificacionPredio : new int?();
            }

            if (peticion.PredioCatastralEn != null)
            {
                idPredioCatastralEn = peticion.PredioCatastralEn.IdPredioCatastralEn != 0 || peticion.PredioCatastralEn.IdPredioCatastralEn != null ? peticion.PredioCatastralEn.IdPredioCatastralEn : new int?();
            }

            if (peticion.UsoPredio != null)
            {
                idUsoPredio = peticion.UsoPredio.IdUsoPredio != 0 || peticion.UsoPredio.IdUsoPredio != null ? peticion.UsoPredio.IdUsoPredio : new int?();
            }

            descripcionPredio.IdClasificacionPredio = idClasificacionPredio;
            descripcionPredio.IdPredioCatastralEn = idPredioCatastralEn;
            descripcionPredio.IdUsoPredio = idUsoPredio;
            descripcionPredio.Estructuracion = peticion.Estructuracion;
            descripcionPredio.Zonificacion = peticion.Zonificacion;
            descripcionPredio.AreaTitulo = peticion.AreaTitulo;
            descripcionPredio.AreaLibre = peticion.AreaLibre;
            descripcionPredio.AreaVerificada = peticion.AreaVerificada;
            descripcionPredio.IdFicha = peticion.IdFicha;
            descripcionPredio.ClasfDescOtros = peticion.ClasfDescOtros;
            descripcionPredio.PredioCatOtros = peticion.PredioCatOtros;
            descripcionPredio.UsoPredioOtros = peticion.UsoPredioOtros;

            if (peticion.LinderoPredio != null)
            {
                peticion.LinderoPredio.Id = descripcionPredio.IdDescripcionPredio;
                await _linderoPredioService.CrearOActualizarAsync(peticion.LinderoPredio);
            }

            if (descripcionPredio.IdDescripcionPredio == 0)
            {
                return await _descripcionPredioRepository.Create(descripcionPredio);
            }
            else
            {
                return await _descripcionPredioRepository.Edit(descripcionPredio.IdDescripcionPredio, descripcionPredio);
            }

        }
    }
}
