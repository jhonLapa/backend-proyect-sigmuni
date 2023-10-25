using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Autoridades.Maps
{
    public class AutoridadProfile : Profile
    {
        public AutoridadProfile()
        {
            CreateMap<Autoridad, AutoridadDto>();
            CreateMap<Autoridad, AutoridadDto>().ReverseMap();

            CreateMap<RequestPagination<Autoridad>, RequestPagination<AutoridadDto>>().ReverseMap();
            CreateMap<ResponsePagination<Autoridad>, ResponsePagination<AutoridadDto>>();
        }
    }
}
