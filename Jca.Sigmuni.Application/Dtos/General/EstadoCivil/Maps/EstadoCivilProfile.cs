using AutoMapper;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Application.Dtos.General.EstadoCivil.Maps
{
    public class EstadoCivilProfile : Profile
    {
        public EstadoCivilProfile()
        {
            CreateMap<Domain.General.EstadoCivil, EstadoCivilDto>();
            CreateMap<Domain.General.EstadoCivil, EstadoCivilDto>().ReverseMap();

            CreateMap<RequestPagination<Domain.General.EstadoCivil>, RequestPagination<EstadoCivilDto>>().ReverseMap();
            CreateMap<ResponsePagination<Domain.General.EstadoCivil>, ResponsePagination<EstadoCivilDto>>();
        }
    }
}