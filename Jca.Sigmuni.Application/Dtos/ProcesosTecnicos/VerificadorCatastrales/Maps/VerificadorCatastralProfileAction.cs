using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.DocumentoIdentidades;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.VerificadorCatastrales.Maps
{
    internal class VerificadorCatastralProfileAction : IMappingAction<Persona, VerificadorCatastralDto>
    {
        public void Process(Persona source, VerificadorCatastralDto destination, ResolutionContext context)
        {
            destination.IdPersona = source.Id;

            if (source.DocumentoIdentidad != null)
            {
                destination.DocumentoIdentidad = context.Mapper.Map<DocumentoIdentidadDto>(source.DocumentoIdentidad);
            }
        }
    }
}
