using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.CompendioNormas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.CompendioNormas.NormasInteres.Maps
{
    public class NormaInteresProfile : Profile
    {
        public NormaInteresProfile()
        {
            CreateMap<NormaInteres, NormaInteresDto>();
            CreateMap<NormaInteres, NormaInteresDto>().ReverseMap();

            CreateMap<RequestPagination<NormaInteres>, RequestPagination<NormaInteresDto>>().ReverseMap();
            CreateMap<ResponsePagination<NormaInteres>, ResponsePagination<NormaInteresDto>>();
        }
    }
}
