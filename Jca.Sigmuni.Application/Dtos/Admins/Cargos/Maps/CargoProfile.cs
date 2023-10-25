using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.Admins.Cargos.Maps
{
    public class CargoProfile : Profile
    {
        public CargoProfile()
        {
            CreateMap<Domain.Admins.Cargo, CargoDto>();
            CreateMap<Domain.Admins.Cargo, CargoDto>().ReverseMap();

            CreateMap<RequestPagination<Domain.Admins.Cargo>, RequestPagination<CargoDto>>().ReverseMap();
            CreateMap<ResponsePagination<Domain.Admins.Cargo>, ResponsePagination<CargoDto>>();
        }
    }
}