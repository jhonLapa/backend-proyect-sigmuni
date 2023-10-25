using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Resultados.Maps
{
    public class ResultadoProfile : Profile
    {
        public ResultadoProfile()
        {
            CreateMap<Resultado, ResultadoDto>();
            CreateMap<Resultado, ResultadoDto>().ReverseMap();

            CreateMap<RequestPagination<Resultado>, RequestPagination<ResultadoDto>>().ReverseMap();
            CreateMap<ResponsePagination<Resultado>, ResponsePagination<ResultadoDto>>();
        }
    }
}
