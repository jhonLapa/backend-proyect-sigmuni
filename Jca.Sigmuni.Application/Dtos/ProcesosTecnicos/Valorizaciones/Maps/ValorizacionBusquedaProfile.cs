using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaBusquedas;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Valorizaciones.Maps
{
    public class ValorizacionBusquedaProfile : Profile
    {
        public ValorizacionBusquedaProfile()
        {
            //CreateMap<FichaBusquedaDto, ValorizacionBusquedaDto>()
            //    .AfterMap<ValorizacionBusquedaProfileAction>();

            //CreateMap<ValorizacionBusquedaDto, FichaBusquedaDto>();

            //CreateMap<RequestPagination<ValorizacionBusquedaDto>, RequestPagination<FichaBusquedaDto>>();
            //CreateMap<ResponsePagination<FichaBusquedaDto>, ResponsePagination<ValorizacionBusquedaDto>>();


            CreateMap<Ficha, ValorizacionBusquedaDto>()
                .AfterMap<ValorizacionBusquedaProfileAction>();
            CreateMap<ValorizacionBusquedaDto, ValorizacionBusqueda>();

            CreateMap<RequestPagination<ValorizacionBusquedaDto>, RequestPagination<ValorizacionBusqueda>>();
            CreateMap<ResponsePagination<Ficha>, ResponsePagination<ValorizacionBusquedaDto>>();


            // AnioReporte
            CreateMap<AnioReporte, AnioReporteDto>();
            CreateMap<AnioReporteDto, AnioReporte>();

            CreateMap<RequestPagination<AnioReporte>, RequestPagination<AnioReporteDto>>().ReverseMap();
            CreateMap<ResponsePagination<AnioReporte>, ResponsePagination<AnioReporteDto>>();
        }
    }
}
