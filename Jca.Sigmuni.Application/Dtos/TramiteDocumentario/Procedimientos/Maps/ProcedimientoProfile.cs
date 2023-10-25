using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Procedimientos.Maps
{
    public class ProcedimientoProfile :Profile
    {
        public ProcedimientoProfile()
        {
            CreateMap<Procedimiento,ProcedimientoDto>();
            CreateMap<Procedimiento, ProcedimientoDto>().ReverseMap();

            CreateMap<RequestPagination<Procedimiento>, RequestPagination<ProcedimientoDto>>().ReverseMap();
            CreateMap<ResponsePagination<Procedimiento>,ResponsePagination<ProcedimientoDto>>();

        }
    }
}
