using AutoMapper;
using Jca.Sigmuni.Application.Dtos.Admins.Domicilios;
using Jca.Sigmuni.Application.Dtos.General.InfoContactos;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.Personas.Maps
{
    public class PersonaSolicitudProfileAction : IMappingAction<Persona, PersonaSolicitudDto>
    {
        public void Process(Persona source, PersonaSolicitudDto destination, ResolutionContext context)
        {
            if (source.Domicilio != null)
            {
                destination.Domicilio = context.Mapper.Map<List<DomicilioDto>>(source.Domicilio);
            }
            if (source.InfoContacto != null)
            {
                destination.InfoContacto = context.Mapper.Map<List<InfoContactoDto>>(source.InfoContacto);
            }
        }
    }
}
