using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.ElementosArquitectonicos.Maps
{
    public class ElementoArquitectonicoProfile : Profile
    {
        public ElementoArquitectonicoProfile()
        {
            CreateMap<ElementoArquitectonico, ElementoArquitectonicoDto>();
            CreateMap<ElementoArquitectonico, ElementoArquitectonicoDto>().ReverseMap();

            CreateMap<RequestPagination<ElementoArquitectonico>, RequestPagination<ElementoArquitectonicoDto>>().ReverseMap();
            CreateMap<ResponsePagination<ElementoArquitectonico>, ResponsePagination<ElementoArquitectonicoDto>>();
        }
    }
}
