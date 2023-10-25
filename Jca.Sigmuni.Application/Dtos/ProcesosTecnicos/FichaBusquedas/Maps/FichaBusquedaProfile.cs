using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaBusquedas.Maps
{
    public class FichaBusquedaProfile:Profile
    {
        public FichaBusquedaProfile()
        {
            CreateMap<FichaBusqueda,FichaBusquedaDto>();
            CreateMap<FichaBusqueda, FichaBusquedaDto>().ReverseMap().AfterMap<FichaBusquedaProfileActionReverse>();

            CreateMap<RequestPagination<FichaBusqueda>, RequestPagination<FichaBusquedaDto>>().ReverseMap();
            CreateMap<ResponsePagination<FichaBusqueda>, ResponsePagination<FichaBusquedaDto>>();
        }   
    }
}
