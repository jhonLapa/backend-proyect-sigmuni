using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.RecapBienComunComplementarios;
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
    public class RecapBienComunComplementarioService : IRecapBienComunComplementarioService
    {
        private readonly IMapper _mapper;
        private readonly IRecapBienComunComplementarioRepository _recapBienComunComplementarioRepository;

        public RecapBienComunComplementarioService(IMapper mapper,
                                                   IRecapBienComunComplementarioRepository recapBienComunComplementarioRepository)
        {
            _mapper = mapper;
            _recapBienComunComplementarioRepository = recapBienComunComplementarioRepository;
        }

        public async Task<RecapBienComunComplementario> CrearAsync(RecapBienComunComplementarioDto peticion)
        {
            var recapBienComunComplementario = new RecapBienComunComplementario
            {
                AnchoPasaje = peticion.AnchoPasaje,
                Distancia = peticion.Distancia,
                IdFicha = peticion.IdFicha
            };

            return await _recapBienComunComplementarioRepository.Create(recapBienComunComplementario);
        }

        public async Task<bool> EliminarPorIdFichaAsync(int idFicha)
        {
            var lista = await _recapBienComunComplementarioRepository.ListarPorIdFichaAsync(idFicha);
            var response = false;

            foreach (var item in lista)
            {
                response = await _recapBienComunComplementarioRepository.EliminarAsync(item.Id);
            }

            return response;
        }
    }
}
