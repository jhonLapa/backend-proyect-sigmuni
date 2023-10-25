using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.CompendioNormas;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.CompendioNormas.ClasificacionNormas.Maps
{
    public class ClasificacionNormaProfile : Profile
    {
        public ClasificacionNormaProfile()
        {
            CreateMap<ClasificacionNorma, ClasificacionNormaDto>();
            CreateMap<ClasificacionNorma, ClasificacionNormaDto>().ReverseMap();

            CreateMap<RequestPagination<ClasificacionNorma>, RequestPagination<ClasificacionNormaDto>>().ReverseMap();
            CreateMap<ResponsePagination<ClasificacionNorma>, ResponsePagination<ClasificacionNormaDto>>();
        }
    }
}
