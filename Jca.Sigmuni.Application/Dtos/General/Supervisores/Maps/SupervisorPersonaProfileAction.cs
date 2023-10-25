using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.DocumentoIdentidades;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.Supervisores.Maps
{
    public class SupervisorPersonaProfileAction : IMappingAction<Persona, SupervisorPersonaDto>
    {
        public void Process(Persona source, SupervisorPersonaDto destination, ResolutionContext context)
        {
            destination.IdPersona = source.Id;

            if (source.DocumentoIdentidad != null)
            {
                destination.DocumentoIdentidad = context.Mapper.Map<DocumentoIdentidadDto>(source.DocumentoIdentidad);
            }
        }
    }
}
