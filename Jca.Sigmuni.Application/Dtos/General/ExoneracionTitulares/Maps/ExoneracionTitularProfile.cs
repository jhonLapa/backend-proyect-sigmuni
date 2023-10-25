using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.ExoneracionTitulares.Maps
{
    public class ExoneracionTitularProfile:Profile
    {
        public ExoneracionTitularProfile() 
        {
            CreateMap<ExoneracionTitular, ExoneracionTitularDto>();
            CreateMap<ExoneracionTitular,ExoneracionTitularDto>().ReverseMap();

            CreateMap<RequestPagination<ExoneracionTitular>, RequestPagination<ExoneracionTitular>>().ReverseMap();
            CreateMap<ResponsePagination<ExoneracionTitular>, ResponsePagination<ExoneracionTitularDto>>();
        }
    }
}
