using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.InfoContactos;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.RepresentantesLegales.Maps
{
    public class RepresentanteLegalProfile : Profile
    {
        public RepresentanteLegalProfile() 
        {
            CreateMap<Persona, RepresentanteLegalDto>();
            CreateMap<Persona, RepresentanteLegalDto>().ReverseMap();

            CreateMap<RequestPagination<RepresentanteLegal>, RequestPagination<RepresentanteLegalDto>>().ReverseMap();
            CreateMap<ResponsePagination<RepresentanteLegal>, ResponsePagination<RepresentanteLegalDto>>();
        }
    }
}
