using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.Personas;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.Manzanas.Maps
{
    public class ManzanaProfile : Profile
    {
        public ManzanaProfile()
        {
            CreateMap<Manzana, ManzanaDto>();
            CreateMap<Manzana, ManzanaDto>().ReverseMap();

            CreateMap<RequestPagination<Manzana>, RequestPagination<ManzanaDto>>().ReverseMap();
            CreateMap<ResponsePagination<Manzana>, ResponsePagination<ManzanaDto>>();
        }
    }

}
