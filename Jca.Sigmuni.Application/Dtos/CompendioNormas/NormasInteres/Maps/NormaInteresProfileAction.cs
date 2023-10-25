using AutoMapper;
using Jca.Sigmuni.Domain.CompendioNormas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.CompendioNormas.NormasInteres.Maps
{
    public class NormaInteresProfileAction : IMappingAction<NormaInteres, NormaInteresDto>
    {
        public void Process(NormaInteres source, NormaInteresDto destination, ResolutionContext context)
        {
            if(source.NormaDerogadas!=null)
            {
                destination.NormaDerogada = context.Mapper.Map<List<NormaDerogadaDto>>(source.NormaDerogadas);
            }
        }
    }
}
