using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UbicacionPredios;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.Habilitaciones.Abstracciones;
using Jca.Sigmuni.Infraestructure.Repositories.Habilitaciones.Implementaciones;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class UbicacionPredioService : IUbicacionPredioService
    {
        private readonly IMapper _mapper;
        private readonly IUbicacionPredioRepository _ubicacionPredioRepository;
        private readonly IHabilitacionUrbanaRepository _habilitacionUrbanaRepository;

        public UbicacionPredioService(IMapper mapper,
                                      IUbicacionPredioRepository ubicacionPredioRepository,
                                      IHabilitacionUrbanaRepository habilitacionUrbanaRepository)
        {
            _mapper = mapper;
            _ubicacionPredioRepository = ubicacionPredioRepository;
            _habilitacionUrbanaRepository = habilitacionUrbanaRepository;
        }

        public async Task<UbicacionPredio?> CrearOActualizarAsync(UbicacionPredioDto peticion)
        {
            var id = peticion.Id;

            var ubicacionPredio = await _ubicacionPredioRepository.Find(id);

            if (ubicacionPredio == null)
            {
                ubicacionPredio = new UbicacionPredio();
            }

            var idHabilitacionUrbana = default(int?);
            if (peticion.HabilitacionUrbana != null)
            {
                if (peticion.HabilitacionUrbana?.IdHabilitacionUrbana != null && peticion.HabilitacionUrbana?.IdHabilitacionUrbana != 0)
                {
                    idHabilitacionUrbana = peticion.HabilitacionUrbana?.IdHabilitacionUrbana;
                }
                else if (!string.IsNullOrWhiteSpace(peticion.HabilitacionUrbana?.IdHUCarto))
                {
                    var habilitacionUrbana = await _habilitacionUrbanaRepository.BuscarPorIdHUCartoAsync(peticion.HabilitacionUrbana.IdHUCarto);
                    if (habilitacionUrbana != null) idHabilitacionUrbana = habilitacionUrbana.IdHabilitacionUrbana;
                }
            }

            ubicacionPredio.DenominacionPredio = peticion.DenominacionPredio;
            ubicacionPredio.IdEdificacion = peticion.IdEdificacion;
            ubicacionPredio.IdHabilitacionUrbana = idHabilitacionUrbana;
            ubicacionPredio.IdFicha = peticion.IdFicha;

            if (ubicacionPredio.IdUbicacionPredio == 0)
            {
                return await _ubicacionPredioRepository.Create(ubicacionPredio);
            }
            else
            {
                return await _ubicacionPredioRepository.Edit(ubicacionPredio.IdUbicacionPredio, ubicacionPredio);
            }
        }
    }
}
