using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.TecnicosCatastrales;
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
    public class TecnicoCatastralService : ITecnicoCatastralService
    {
        private readonly IMapper _mapper;
        private readonly ITecnicoCatastralRepository _tecnicoCatastralRepository;

        public TecnicoCatastralService(IMapper mapper,
                                       ITecnicoCatastralRepository tecnicoCatastralRepository)
        {
            _mapper = mapper;
            _tecnicoCatastralRepository = tecnicoCatastralRepository;
        }

        public async Task<TecnicoCatastral?> GuardarPersonaTecnicoCatastralAsync(TecnicoCatastralPersonaDto peticion)
        {
            //if (string.IsNullOrEmpty(peticion.IdPersona)) return new OperacionDto<RespuestaSimpleDto<long>>(CodigosOperacionDto.Invalido, "No ha ingresado la persona tecnico.");

            var idTecnico = peticion.IdTecnico;

            var tecnicoCatastral = await _tecnicoCatastralRepository.Find(idTecnico);

            if (tecnicoCatastral == null) tecnicoCatastral = new TecnicoCatastral();

            tecnicoCatastral.Fecha = peticion.Fecha;
            tecnicoCatastral.IdPersona = peticion.IdPersona;
            tecnicoCatastral.IdFicha = peticion.IdFicha;
            tecnicoCatastral.TieneFirma = peticion.TieneFirma;

            if (tecnicoCatastral.IdTecnicoCatastral == 0) return await _tecnicoCatastralRepository.Create(tecnicoCatastral);
            else return await _tecnicoCatastralRepository.Edit(tecnicoCatastral.IdTecnicoCatastral, tecnicoCatastral);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var entidad = await _tecnicoCatastralRepository.Find(id);
            if (entidad == null)
            {
                return false;
            }

            return await _tecnicoCatastralRepository.EliminarAsync(entidad.IdTecnicoCatastral);
        }
    }
}
