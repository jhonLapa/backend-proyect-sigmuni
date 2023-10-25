using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.TipoExoneraciones.Maps
{
    public class TipoExoneraxionProfile :Profile
    {
        public TipoExoneraxionProfile() 
        {
            CreateMap<TipoExoneracion, TipoExoneracionDto>();
            CreateMap<TipoExoneracion, TipoExoneracionDto>().ReverseMap();

            CreateMap<RequestPagination<TipoExoneracion>, RequestPagination<TipoExoneracionDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoExoneracion>, ResponsePagination<TipoExoneracionDto>>();
        }
    }
}
