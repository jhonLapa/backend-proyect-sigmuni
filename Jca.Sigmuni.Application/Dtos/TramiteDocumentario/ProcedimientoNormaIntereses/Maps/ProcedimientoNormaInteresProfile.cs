using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.ProcedimientoNormaIntereses.Maps
{
    public class ProcedimientoNormaInteresProfile :Profile
    {
        public ProcedimientoNormaInteresProfile()
        {
            CreateMap<ProcedimientoNormaInteres, ProcedimientoNormaInteresDto>();
            CreateMap<ProcedimientoNormaInteres, ProcedimientoNormaInteresDto>().ReverseMap(); ;

            CreateMap<RequestPagination<ProcedimientoNormaInteres>, RequestPagination<ProcedimientoNormaInteresDto>>().ReverseMap();
            CreateMap<ResponsePagination<ProcedimientoNormaInteres>, ResponsePagination<ProcedimientoNormaInteresDto>>();
        }
    }
}
