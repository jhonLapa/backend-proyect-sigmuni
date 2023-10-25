using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.InfoContactos.Maps
{
    public class InfoContactoProfile : Profile
    {
        public InfoContactoProfile() 
        {
            CreateMap<InfoContacto, InfoContactoDto>();
            CreateMap<InfoContacto, InfoContactoDto>().ReverseMap();

            CreateMap<RequestPagination<InfoContacto>, RequestPagination<InfoContactoDto>>().ReverseMap();
            CreateMap<ResponsePagination<InfoContacto>, ResponsePagination<InfoContactoDto>>();
        }
    }
}
