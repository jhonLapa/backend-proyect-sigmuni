using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.Dependientes;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class DependienteService : IDependienteService
    {
        private readonly IMapper _mapper;
        private readonly IDependienteRepository _dependienteRepository;

        public DependienteService(IMapper mapper,
                                  IDependienteRepository dependienteRepository)
        {
            _mapper = mapper;
            _dependienteRepository = dependienteRepository;
        }

        public async Task<Dependiente?> GuardaronyugeTitularAsync(ConyugeTitularDto peticion)
        {
            //if (string.IsNullOrEmpty(peticion.IdPersona)) return new OperacionDto<RespuestaSimpleDto<long>>(CodigosOperacionDto.Invalido, "No ha ingresado a la persona conyuge.");

            var idConyugue = peticion.IdConyugue;
            var dependiente = await _dependienteRepository.Find(idConyugue);

            if (dependiente == null) dependiente = new Dependiente();

            dependiente.Relacion = "Conyuge";
            dependiente.IdPersona = peticion.IdPersona;
            dependiente.IdTitularCatastral = peticion.IdTitularCatastral;

            if (dependiente.Id == 0) return await _dependienteRepository.Create(dependiente);
            else return await _dependienteRepository.Edit(dependiente.Id, dependiente);
        }

        public async Task<Dependiente?> GuardarConyugeLitiganteAsync(ConyugeLitiganteDto peticion)
        {
            //if (string.IsNullOrEmpty(peticion.IdPersona)) return new OperacionDto<RespuestaSimpleDto<long>>(CodigosOperacionDto.Invalido, "No ha ingresado a la persona conyuge.");

            var dependiente = new Dependiente
            {
                Relacion = "Conyuge",
                IdPersona = peticion.IdPersona,
                IdLitigante = peticion.IdLitigante
            };

            return await _dependienteRepository.Create(dependiente);
        }

        public async Task<bool> EliminarPorIdTitularCatastralAsync(int idTitularCatastral)
        {
            var lista = await _dependienteRepository.ListarPorIdTitularCatastralAsync(idTitularCatastral);
            var response = false;
            foreach (var item in lista)
            {
               response = await _dependienteRepository.EliminarAsync(item.Id);

            }
            

            return response;
        }
    }
}
