using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.DocumentoIdentidades;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.TecnicosCatastrales.Maps
{
    public class TecnicoCatastralPersonaProfileAction : IMappingAction<Persona, TecnicoCatastralPersonaDto>
    {
        public void Process(Persona source, TecnicoCatastralPersonaDto destination, ResolutionContext context)
        {
            destination.IdPersona = source.Id;

            if (source.DocumentoIdentidad != null)
            {
                destination.DocumentoIdentidad = context.Mapper.Map<DocumentoIdentidadDto>(source.DocumentoIdentidad);
            }
        }
    }
}
