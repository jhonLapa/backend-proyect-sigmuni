using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.EstadoNormas.Maps
{
    public class EstadoNormaProfile : Profile
    {
        public EstadoNormaProfile()
        {
            CreateMap<EstadoNorma, EstadoNormaDto>();
            CreateMap<EstadoNorma, EstadoNormaDto>().ReverseMap();

            CreateMap<RequestPagination<EstadoNorma>, RequestPagination<EstadoNormaDto>>().ReverseMap();
            CreateMap<ResponsePagination<EstadoNorma>, ResponsePagination<EstadoNormaDto>>();
        }
    }
}
