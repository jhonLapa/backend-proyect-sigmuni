using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.RecapitulacionEdificios;
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
    public class RecapitulacionEdificioService : IRecapitulacionEdificioService
    {
        private readonly IMapper _mapper;
        private readonly IRecapitulacionEdificioRepository _recapitulacionEdificioRepository;

        public RecapitulacionEdificioService(IMapper mapper,
                                             IRecapitulacionEdificioRepository recapitulacionEdificioRepository)
        {
            _mapper = mapper;
            _recapitulacionEdificioRepository = recapitulacionEdificioRepository;
        }

        public async Task<RecapitulacionEdificio> CrearAsync(RecapitulacionEdificioDto peticion)
        {
            var recapitulacionEdificio = new RecapitulacionEdificio
            {
                Edificio = peticion.Edificio,
                TotalPorcentaje = peticion.TotalPorcentaje,
                TotalAtc = peticion.TotalAtc,
                TotalAcc = peticion.TotalAcc,
                TotalAoic = peticion.TotalAoic,
                IdFicha = peticion.IdFicha
            };

            return await _recapitulacionEdificioRepository.Create(recapitulacionEdificio);
        }

        public async Task<bool> EliminarPorIdFichaAsync(int idFicha)
        {
            var lista = await _recapitulacionEdificioRepository.ListarPorIdFichaAsync(idFicha);
            var response = false;

            foreach (var item in lista)
            {
                response = await _recapitulacionEdificioRepository.EliminarAsync(item.Id);
            }

            return response;
        }
    }
}
