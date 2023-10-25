using AutoMapper;

namespace Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.TipoPrestamo.Maps
{
    public class TipoPrestamoFormProfile : Profile
    {
        public TipoPrestamoFormProfile()
        {
            CreateMap<Domain.General.TipoPrestamo, TipoPrestamoFormDto>().ReverseMap();
        }
    }
}
