using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.Motivos.Maps
{
    public class MotivoProfile : Profile
    {
        public MotivoProfile()
        {
            CreateMap<Motivo, MotivoDto>();
            CreateMap<Motivo, MotivoDto>().ReverseMap();

            CreateMap<RequestPagination<Motivo>, RequestPagination<MotivoDto>>().ReverseMap();
            CreateMap<ResponsePagination<Motivo>, ResponsePagination<MotivoDto>>();
        }
    }
}
