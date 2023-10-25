using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.TipoExoneraciones;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.Dependientes.Maps
{
    public class ConyugeTitularProfile : Profile
    {
        public ConyugeTitularProfile()
        {
            CreateMap<Persona, ConyugeTitularDto>();
        }
    }
}
