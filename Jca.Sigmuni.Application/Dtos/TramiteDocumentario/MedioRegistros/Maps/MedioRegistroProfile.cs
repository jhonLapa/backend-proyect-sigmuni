using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.MedioRegistros.Maps
{
    public class MedioRegistroProfile : Profile
    {
        public MedioRegistroProfile()
        {
            CreateMap<MedioRegistro, MedioRegistroDto>();
            CreateMap<MedioRegistro, MedioRegistroDto>().ReverseMap();

            CreateMap<RequestPagination<MedioRegistro>, RequestPagination<MedioRegistroDto>>().ReverseMap();
            CreateMap<ResponsePagination<MedioRegistro>, ResponsePagination<MedioRegistroDto>>();
        }
    }
}
