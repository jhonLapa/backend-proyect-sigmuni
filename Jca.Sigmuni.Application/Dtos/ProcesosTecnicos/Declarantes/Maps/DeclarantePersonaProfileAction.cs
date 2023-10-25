using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.DocumentoIdentidades;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Declarantes.Maps
{
    public class DeclarantePersonaProfileAction : IMappingAction<Persona, DeclarantePersonaDto>
    {
        public void Process(Persona source, DeclarantePersonaDto destination, ResolutionContext context)
        {
            destination.IdPersona = source.Id;

            if (source.DocumentoIdentidad != null)
            {
                destination.DocumentoIdentidad = context.Mapper.Map<DocumentoIdentidadDto>(source.DocumentoIdentidad);
            }
        }
    }
}
