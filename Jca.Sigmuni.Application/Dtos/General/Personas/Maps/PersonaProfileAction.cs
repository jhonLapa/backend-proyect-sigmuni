using AutoMapper;
using Jca.Sigmuni.Application.Dtos.Admins.Domicilios;
using Jca.Sigmuni.Application.Dtos.General.DocumentoIdentidades;
using Jca.Sigmuni.Application.Dtos.General.ExoneracionTitulares;
using Jca.Sigmuni.Application.Dtos.General.InfoContactos;
using Jca.Sigmuni.Application.Dtos.General.RepresentantesLegales;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.Personas.Maps
{
    class PersonaProfileAction : IMappingAction<Persona, PersonaDto>
    {
        public void Process(Persona source, PersonaDto destination, ResolutionContext context)
        {
            if (source.InfoContacto != null)
            {
                destination.InfoContacto = context.Mapper.Map<List<InfoContactoDto>>(source.InfoContacto);
            }
            if (source.Domicilio != null)
            {
                destination.Domicilio = context.Mapper.Map<List<DomicilioDto>>(source.Domicilio);
            }
            if (source.ExoneracionTitulares != null)
            {
                destination.ExoneracionTitulares = context.Mapper.Map<List<ExoneracionTitularDto>>(source.ExoneracionTitulares);
            }
            if(source.RepresentanteLegalDD!=null)
            {
                destination.RepresentanteLegalDD = context.Mapper.Map<RepresentanteLegalDto>(source.RepresentanteLegalDD);
            }
            if (source.DocumentoIdentidad != null)
            {
                destination.DocumentoIdentidad = context.Mapper.Map <DocumentoIdentidadDto>(source.DocumentoIdentidad) ;
            }
        }
    }
}
