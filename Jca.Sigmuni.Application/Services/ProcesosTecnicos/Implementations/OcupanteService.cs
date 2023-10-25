using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ocupantes;
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
    public class OcupanteService : IOcupanteService
    {
        private readonly IMapper _mapper;
        private readonly IOcupanteRepository _ocupanteRepository;

        public OcupanteService(IMapper mapper,
                               IOcupanteRepository ocupanteRepository)
        {
            _mapper = mapper;
            _ocupanteRepository = ocupanteRepository;
        }

        public async Task<bool> EliminarOcupantesPorIdFichaAsync(int idFicha)
        {
            var listaOcupantes = await _ocupanteRepository.BuscarPorIdFichaAsync(idFicha);
            var response = false;

            if (listaOcupantes == null || listaOcupantes.Count == 0)
            {
                return false;
            }

            foreach (var ocupante in listaOcupantes)
            {
                response = await _ocupanteRepository.EliminarAsync(ocupante.Id);
            }

            return response;
        }

        public async Task<Ocupante?> GuardarPersonaOcupanteAsync(OcupantePersonaDto peticion)
        {
            //if (string.IsNullOrEmpty(peticion.Id)) return new OperacionDto<RespuestaSimpleDto<long>>(CodigosOperacionDto.Invalido, "No ha ingresado la persona ocupante.");

            var idOcupante = peticion.Id;
            var ocupante = await _ocupanteRepository.Find(idOcupante);

            if (ocupante == null) ocupante = new Ocupante();

            ocupante.IdFicha = peticion.IdFicha;


            if (peticion.CondicionPer != null) ocupante.IdCondicionPer = peticion.CondicionPer.IdCondicionPer;

            if (ocupante.Id == 0)
            {
                ocupante.Id = idOcupante;
                return await _ocupanteRepository.Create(ocupante);
            }
            else return await _ocupanteRepository.Edit(ocupante.Id, ocupante);
        }
    }
}
