using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Sunarps;
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
    public class SunarpService : ISunarpService
    {
        private readonly IMapper _mapper;
        private readonly ISunarpRepository _sunarpRepository;

        public SunarpService(IMapper mapper,
                              ISunarpRepository sunarpRepository)
        {
            _mapper = mapper;
            _sunarpRepository = sunarpRepository;
        }

        public async Task<bool> EliminarPorIdFichaAsync(int idFicha)
        {
            var listaPuerta = await _sunarpRepository.ListarPorIdFichaAsync(idFicha);
            var response = false;

            foreach (var item in listaPuerta)
            {
                response = await _sunarpRepository.EliminarAsync(item.Id);
            }

            return response;
        }

        public async Task<Sunarp> CrearAsync(SunarpDto peticion)
        {
            var idTipoPartidaRegistral = default(int?);
            if (peticion.TipoPartidaRegistral != null)
            {
                idTipoPartidaRegistral = peticion.TipoPartidaRegistral.IdTipoPartidaRegistral != 0 ? peticion.TipoPartidaRegistral.IdTipoPartidaRegistral : new int?();
            }

            var idTipoTituloInscrito = default(int?);
            if (peticion.TipoTituloInscrito != null)
            {
                idTipoTituloInscrito = peticion.TipoTituloInscrito.IdTipoTituloInscrito != 0 ? peticion.TipoTituloInscrito.IdTipoTituloInscrito : new int?();
            }

            var sunarp = new Sunarp
            {
                NumeroPartida = peticion.NumeroPartida,
                Fojas = peticion.Fojas,
                Asiento = peticion.Asiento,
                DeclaratoriaFabrica = peticion.DeclaratoriaFabrica,
                FechaInscripcion = peticion.FechaInscripcion,
                AsientoFabrica = peticion.AsientoFabrica,
                FechaFabrica = peticion.FechaFabrica,
                IdTipoPartidaRegistral = idTipoPartidaRegistral,
                IdFicha = peticion.IdFicha,
                IdMonumentoPre = peticion.IdMonumentoPre,
                IdMonumentoColonial = peticion.IdMonumentoColonial,
                IdTipoTituloInscrito = idTipoTituloInscrito
            };

            return await _sunarpRepository.Create(sunarp);
        }
    }
}
