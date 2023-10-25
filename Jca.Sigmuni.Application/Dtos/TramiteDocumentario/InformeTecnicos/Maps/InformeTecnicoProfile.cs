using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.SolicitudCucs;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.InformeTecnicos.Maps
{
    public class InformeTecnicoProfile : Profile
    {
        public InformeTecnicoProfile()
        {

            CreateMap<InformeTecnico, InformeTecnicoDto>();
            CreateMap<InformeTecnico, InformeTecnicoDto>().ReverseMap();

            CreateMap<InformeTecnico, InformeTecnicoPaginadoDto>();
            CreateMap<InformeTecnico, InformeTecnicoPaginadoDto>().ReverseMap();

            CreateMap<RequestPagination<InformeTecnico>, RequestPagination<InformeTecnicoPaginadoDto>>().ReverseMap();
            CreateMap<ResponsePagination<InformeTecnico>, ResponsePagination<InformeTecnicoPaginadoDto>>();

        }
    }
}
