using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.TipoPersonas.Maps
{
    public class TipoPersonaProfile : Profile
    {
        public TipoPersonaProfile()
        {
            CreateMap<TipoPersona, TipoPersonaDto>();
            CreateMap<TipoPersona, TipoPersonaDto>().ReverseMap();

            CreateMap<RequestPagination<TipoPersona>, RequestPagination<TipoPersonaDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoPersona>, ResponsePagination<TipoPersonaDto>>();
        }
    }
}

