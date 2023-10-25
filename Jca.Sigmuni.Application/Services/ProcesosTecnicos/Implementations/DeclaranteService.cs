using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Declarantes;
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
    public class DeclaranteService : IDeclaranteService
    {
        private readonly IMapper _mapper;
        private readonly IDeclaranteRepository _declaranteRepository;

        public DeclaranteService(IMapper mapper,
                                 IDeclaranteRepository declaranteRepository)
        {
            _mapper = mapper;
            _declaranteRepository = declaranteRepository;
        }

        public async Task<Declarante?> GuardarDeclaranteAsync(DeclarantePersonaDto peticion)
        {
            var idDeclarante = peticion.IdDeclarante;
            var declarante = await _declaranteRepository.FindById(idDeclarante);

            if (declarante == null) declarante = new Declarante();

            declarante.Fecha = peticion.Fecha;
            declarante.IdFicha = peticion.IdFicha;
            declarante.TieneFirma = peticion.TieneFirma;

            if (peticion.IdPersona != 0) declarante.IdPersona = peticion.IdPersona;
            if (peticion.CondicionPer != null) declarante.IdCondicionPer = peticion.CondicionPer.IdCondicionPer == 0 ? null : peticion.CondicionPer.IdCondicionPer;

            if (peticion.IdPersona != 0 && peticion.CondicionPer?.IdCondicionPer != 0 && declarante == null)
            {
                declarante = new Declarante();

                declarante.IdFicha = peticion.IdFicha;
                declarante.IdCondicionPer = peticion.CondicionPer?.IdCondicionPer;
            }
            if(peticion.TieneFirma == null)
            {
                declarante.TieneFirma = false;
            }
            else
            {
                declarante.TieneFirma = peticion.TieneFirma;
            }
            if (declarante.IdDeclarante == 0) return await _declaranteRepository.Create(declarante);
            else return await _declaranteRepository.Edit(declarante.IdDeclarante, declarante);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var entidad = await _declaranteRepository.FindById(id);
            if (entidad == null)
            {
                return false;
            }

            return await _declaranteRepository.EliminarAsync(entidad.IdDeclarante);
        }
    }
}
