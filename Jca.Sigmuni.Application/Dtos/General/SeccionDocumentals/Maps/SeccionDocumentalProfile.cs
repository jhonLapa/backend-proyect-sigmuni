using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.SeccionDocumentals.Maps
{
    public class SeccionDocumentalProfile : Profile
    {
        public SeccionDocumentalProfile()
        {
            CreateMap<Domain.General.SeccionDocumental, SeccionDocumentalDto>();
            CreateMap<Domain.General.SeccionDocumental, SeccionDocumentalDto>().ReverseMap();

            CreateMap<RequestPagination<Domain.General.SeccionDocumental>, RequestPagination<SeccionDocumentalDto>>().ReverseMap();
            CreateMap<ResponsePagination<Domain.General.SeccionDocumental>, ResponsePagination<SeccionDocumentalDto>>();
        }
    }
}
