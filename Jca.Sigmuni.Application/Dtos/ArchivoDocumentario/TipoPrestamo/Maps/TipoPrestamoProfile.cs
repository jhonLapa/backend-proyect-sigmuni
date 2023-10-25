using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.TipoPrestamo.Maps
{
    public class TipoPrestamoProfile : Profile
    {
        public TipoPrestamoProfile()
        {
            CreateMap<Domain.General.TipoPrestamo, TipoPrestamoDto>();
            CreateMap<Domain.General.TipoPrestamo, TipoPrestamoDto>().ReverseMap();

            CreateMap<RequestPagination<Domain.General.TipoPrestamo>, RequestPagination<TipoPrestamoDto>>().ReverseMap();
            CreateMap<ResponsePagination<Domain.General.TipoPrestamo>, ResponsePagination<TipoPrestamoDto>>();
        }
    }
}
