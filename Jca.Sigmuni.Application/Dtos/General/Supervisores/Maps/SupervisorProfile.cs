using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Declarantes;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.Supervisores.Maps
{
    public class SupervisorProfile : Profile
    {
        public SupervisorProfile()
        {
            CreateMap<Supervisor, SupervisorDto>();
            CreateMap<Supervisor, SupervisorDto>().ReverseMap();

            CreateMap<RequestPagination<Supervisor>, RequestPagination<SupervisorDto>>().ReverseMap();
            CreateMap<ResponsePagination<Supervisor>, ResponsePagination<SupervisorDto>>();
        }
    }
}
