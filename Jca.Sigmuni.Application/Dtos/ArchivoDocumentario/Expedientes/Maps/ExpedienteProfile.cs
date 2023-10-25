using AutoMapper;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.Expedientes.Maps
{
    public class ExpedienteProfile : Profile
    {
        public ExpedienteProfile()
        {
            CreateMap<Domain.ArchivoDocumentario.Expediente, ExpedienteDto>();
            CreateMap<Domain.ArchivoDocumentario.Expediente, ExpedienteDto>().ReverseMap();

            CreateMap<RequestPagination<Domain.ArchivoDocumentario.Expediente>, RequestPagination<ExpedienteDto>>().ReverseMap();
            CreateMap<ResponsePagination<Domain.ArchivoDocumentario.Expediente>, ResponsePagination<ExpedienteDto>>();
        }
    }
}
