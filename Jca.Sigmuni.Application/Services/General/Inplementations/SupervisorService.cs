using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.Supervisores;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.General.Inplementations
{
    public class SupervisorService : ISupervisorService
    {
        private readonly IMapper _mapper;
        private readonly ISupervisorRepository _supervisorRepository;

        public SupervisorService(IMapper mapper,
                                  ISupervisorRepository supervisorRepository)
        {
            _mapper = mapper;
            _supervisorRepository = supervisorRepository;
        }

        public async Task<Supervisor?> GuardarPersonaSupervisorAsync(SupervisorPersonaDto peticion)
        {
            //if (string.IsNullOrEmpty(peticion.IdPersona)) return new OperacionDto<RespuestaSimpleDto<long>>(CodigosOperacionDto.Invalido, "No ha ingresado la persona supervisor.");

            var idSupervisor = peticion.IdSupervisor;
            var supervisor = await _supervisorRepository.Find(idSupervisor);

            if (supervisor == null) supervisor = new Supervisor();

            supervisor.Fecha = peticion.Fecha;
            supervisor.IdPersona = peticion.IdPersona;
            supervisor.IdFicha = peticion.IdFicha;
            supervisor.TieneFirma = peticion.TieneFirma;

            if (supervisor.IdSupervisor == 0) return await _supervisorRepository.Create(supervisor);
            else return await _supervisorRepository.Edit(supervisor.IdSupervisor, supervisor);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var entidad = await _supervisorRepository.Find(id);
            if (entidad == null)
            {
                return false;
            }

            return await _supervisorRepository.EliminarAsync(entidad.IdSupervisor);
        }
    }
}
